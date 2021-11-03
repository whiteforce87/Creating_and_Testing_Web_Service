using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using bau_api.Models;

namespace bau_api
{
    public class DB
    {
        #region Members
        static string connStr = *//write here the code from mongoDB
        static string dbName = "test2"; 
        #endregion

        public static  List<PlanetInfo> GetPlanet()
        {
            var dbClient = new MongoClient(connStr);
            var db = dbClient.GetDatabase(dbName);
            var planets = db.GetCollection<BsonDocument>("planets");
            var planetsList = planets.Find(new BsonDocument()).ToList();

            List<PlanetInfo> data = new List<PlanetInfo>();
            foreach (BsonDocument doc in planetsList)
            {
                PlanetInfo planet = BsonSerializer.Deserialize<PlanetInfo>(doc);
                data.Add(planet);
            }

            return data;
        }

        public static string AddPlanet(PlanetInfo planets)
        {
            string strResultMessage = string.Empty;

            try
            {
                var client = new MongoClient(connStr);
                var mongoDB = client.GetDatabase(dbName);
                var collection = mongoDB.GetCollection<BsonDocument>("planets");

                collection.InsertOne(planets.ToBsonDocument());

                strResultMessage = "Successfully added.";
            }
            catch(Exception exc)
            {
                strResultMessage = exc.Message;
            }

            return strResultMessage;
        }
        public static string UpdatePlanets(PlanetInfo planets)
        {
            string strResultMessage = string.Empty;

            try
            {
                var client = new MongoClient(connStr);
                var mongoDB = client.GetDatabase(dbName);
                var collection = mongoDB.GetCollection<BsonDocument>("planets");

                var filter = Builders<BsonDocument>.Filter.Eq("PlanetId", planets.PlanetId);

                var updateName = Builders<BsonDocument>.Update.Set("PlanetName", planets.PlanetName);
                collection.UpdateOne(filter, updateName);

                var updateDistance = Builders<BsonDocument>.Update.Set("DistanceToSun", planets.DistanceToSun);
                collection.UpdateOne(filter, updateDistance);

                strResultMessage = "Update successfull";
            }
            catch(Exception exc)
            {
                strResultMessage = exc.Message;
            }

            return strResultMessage;
        }
        public static string DeletePlanet(long PlanetId)
        {
            string strResultMessage = string.Empty;

            try
            {
                var client = new MongoClient(connStr);
                var mongoDB = client.GetDatabase(dbName);
                var collection = mongoDB.GetCollection<BsonDocument>("planets");

                var filter = Builders<BsonDocument>.Filter.Eq("PlanetId", PlanetId);

                collection.DeleteOne(filter);

                strResultMessage = "Delete succeeded.";
            }
            catch(Exception exc)
            {
                strResultMessage = exc.Message;
            }

            return strResultMessage;
        }
    }
}
