using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bau_api.Models
{
    public class PlanetInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string _id { get; set; }

        public string PlanetName { get; set; }
        public long PlanetId { get; set; }
        public string DistanceToSun { get; set; }
    }
}
