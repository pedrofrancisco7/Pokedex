using System;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pokedex.Data.Interfaces;

namespace Pokedex.Data.Context
{
    public class DbContext : IDbContext
    {
        private IMongoDatabase _database;

        public DbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            if (client != null)
                _database = client.GetDatabase("Pokedex");
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }
    }
}

