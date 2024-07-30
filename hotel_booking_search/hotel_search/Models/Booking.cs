using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Bookings
{
      [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("phone")]
        public string Phone { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("rating")]
        public double Rating { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("amenities")]
        public List<string> Amenities { get; set; }
}