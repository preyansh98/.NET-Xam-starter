using ProfileAPI.Domain;
using MongoDB.Driver;
using System.Collections.Generic;
using System;

namespace ProfileAPI.Services
{
    public class ProfileService
    {
        private readonly IMongoCollection<UserProfile> _profiles;

        public ProfileService(IProfileDatabaseSettings settings)
        {
            var client = new MongoClient(settings.DbConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _profiles = database.GetCollection<UserProfile>(settings.CollectionName);
        }

        public List<UserProfile> Get() =>
            _profiles.Find(profile => true).ToList();

        public UserProfile Get(string id) =>
            _profiles.Find<UserProfile>(profile => profile.Id == id).FirstOrDefault();

        public UserProfile Create(UserProfile profile)
        {
            _profiles.InsertOne(profile);
            return profile;
        }

        public void Update(string id, UserProfile profileIn) =>
            _profiles.ReplaceOne(profile => profile.Id == id, profileIn);

        public void Remove(UserProfile bookIn) =>
            _profiles.DeleteOne(profile => profile.Id == bookIn.Id);

        public void Remove(string id) => 
            _profiles.DeleteOne(profile => profile.Id == id);
    }
}