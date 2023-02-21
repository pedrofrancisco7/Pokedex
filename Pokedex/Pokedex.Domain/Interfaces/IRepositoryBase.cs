using System;
namespace Pokedex.Domain.Interfaces
{
	public interface IRepositoryBase<T> where T : class
	{
        Task<T> InsertAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<bool> DeleteAsync(string id);
        Task<T?> SelectAsync(string id);
        Task<IEnumerable<T>> SelectAsync();
    }
}

