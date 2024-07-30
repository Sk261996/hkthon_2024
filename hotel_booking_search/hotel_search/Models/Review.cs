using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Reviews")]
public class Reviews
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("hotelId")]
    public string HotelId { get; set; }

    [BsonElement("guestName")]
    public string GuestName { get; set; }

    [BsonElement("review")]
    public string ReviewText { get; set; }

    [BsonElement("rating")]
    public int Rating { get; set; }
}