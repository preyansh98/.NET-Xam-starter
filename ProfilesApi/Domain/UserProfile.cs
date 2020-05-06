using System.Collections.Generic; 
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProfileAPI.Domain {

    public class UserProfile {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        string Name { get; set; }
        HashSet<string> Emails { get; set; } 
    }
}

