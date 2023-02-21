using System;
using Pokedex.Domain.Entities;

namespace Pokedex.Service.Interfaces;

public interface IPokemonService : IServiceBase<Pokemon>
{
    Task<IEnumerable<Pokemon>> GetPokemonByNumero(int numero);    
    Task<IEnumerable<Pokemon>> GetPokemonsByNome(string nome);
    Task<IEnumerable<Pokemon>> GetPokemonsByTipo(string tipo);

    Task<Pokemon> UpdatePokemon(Pokemon pokemon);
}

