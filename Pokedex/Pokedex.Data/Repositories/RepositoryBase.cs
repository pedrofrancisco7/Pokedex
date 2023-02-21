using System;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using Pokedex.Data.Interfaces;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Data.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{

    private readonly IDbContext _dbContext;
    private readonly string _tabela;

    public RepositoryBase(IDbContext dbContext)
    {
        _dbContext = dbContext;
        var type = typeof(T);
        _tabela = Utils.Utils.GetTableName(type);


    }

    public async Task<bool> DeleteAsync(string id)
    {
        var collection = _dbContext.GetDatabase().GetCollection<T>(_tabela);
        return false;
    }

    public Task<T> InsertAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<T?> SelectAsync(string id)
    {
        var collection = _dbContext.GetDatabase().GetCollection<T>(_tabela);

        return await collection.Find(new BsonDocument("id", id)).FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<T>> SelectAsync()
    {
        var collection = _dbContext.GetDatabase().GetCollection<T>(_tabela);

        return await collection.Find(_ => true).ToListAsync();
    }

    public async Task<T?> UpdateAsync(T entity)
    {
        throw new Exception();
    }
}

