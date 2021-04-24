using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Models
{
    public class People
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
    }
}
