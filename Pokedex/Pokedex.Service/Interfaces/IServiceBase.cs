using System;
namespace Pokedex.Service.Interfaces;

public interface IServiceBase<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(string id);
    Task<T?> SelectAsync(string id);
    Task<IEnumerable<T>> SelectAsync();
}

