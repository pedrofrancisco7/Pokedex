using System;
using MongoDB.Driver;

namespace Pokedex.Data.Interfaces;

public interface IDbContext
{
	IMongoDatabase GetDatabase();
}

