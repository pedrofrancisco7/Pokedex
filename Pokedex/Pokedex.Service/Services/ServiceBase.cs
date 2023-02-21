using System;
using Pokedex.Domain.Interfaces;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Services;

public class ServiceBase<T> : IServiceBase<T> where T : class
{
    private IRepositoryBase<T> _repositoryBase;

    public ServiceBase(IRepositoryBase<T> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public Task<bool> DeleteAsync(string id)
    {
        return _repositoryBase.DeleteAsync(id);
    }

    public Task<T> InsertAsync(T entity)
    {
        return _repositoryBase.InsertAsync(entity);
    }

    public Task<T?> SelectAsync(string id)
    {
        return _repositoryBase.SelectAsync(id);
    }

    public Task<IEnumerable<T>> SelectAsync()
    {
        return _repositoryBase.SelectAsync();
    }

    public Task<T?> UpdateAsync(T entity)
    {
        return _repositoryBase.UpdateAsync(entity);
    }
}

