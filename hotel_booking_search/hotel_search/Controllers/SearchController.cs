using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace hotel_search.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly IMongoCollection<Hotels> _hotelsCollection;
        private readonly IMongoCollection<Reviews> _reviewsCollection;

        public HotelsController(IMongoDatabase database)
        {
            _hotelsCollection = database.GetCollection<Hotels>("hotels");
            _reviewsCollection = database.GetCollection<Reviews>("reviews");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotels>>> SearchHotels(string searchString)
        {
            var filter = Builders<Reviews>.Filter.Text(searchString);
            var reviews = await _reviewsCollection.Find(filter).ToListAsync();

            var hotelIds = reviews.Select(r => r.HotelId).Distinct();
            var hotels = await _hotelsCollection.Find(h => hotelIds.Contains(h.Id)).ToListAsync();

            return Ok(hotels);
        }
    }
}