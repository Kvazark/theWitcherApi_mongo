using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Mongo_TheWitcherApi.Models;
using MongoDB.Driver;

namespace Mongo_TheWitcherApi.Services
{
    public class HuntingService
    {
        private readonly IMongoCollection<Hunt> _huntingCollection;
        
        public HuntingService(
            IOptions<HuntingDatabaseSettings> huntingDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                huntingDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                huntingDatabaseSettings.Value.DatabaseName);

            _huntingCollection = mongoDatabase.GetCollection<Hunt>(
                huntingDatabaseSettings.Value.HuntingCollectionName);
        }
        // </snippet_ctor>

        public async Task<List<Hunt>> GetAsync() =>
            await _huntingCollection.Find(_ => true).ToListAsync();

        public async Task<Hunt?> GetAsync(string id) =>
            await _huntingCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Hunt newHunt) =>
            await _huntingCollection.InsertOneAsync(newHunt);

        public async Task UpdateAsync(string id, Hunt updatedHunt) =>
            await _huntingCollection.ReplaceOneAsync(x => x.Id == id, updatedHunt);

        public async Task RemoveAsync(string id) =>
            await _huntingCollection.DeleteOneAsync(x => x.Id == id);
    }
}