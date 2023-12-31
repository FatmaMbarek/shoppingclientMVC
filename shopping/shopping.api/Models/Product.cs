﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace shopping.api.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImageFile { get; set; } = String.Empty;
        public decimal Price { get; set; }
    }
}
