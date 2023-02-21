using System;
using Pokedex.Domain.Entities;

namespace Pokedex.Domain.Interfaces;

public interface IPokemonRepository
{
    Task<IEnumerable<Pokemon>> GetPokemonByNumero(int numero);
    Task<Pokemon> GetPokemonByNome(string nome);
    Task<IEnumerable<Pokemon>> GetPokemonsByNome(string nome);
    Task<IEnumerable<Pokemon>> GetPokemonsByTipo(string tipo);

    Task<Pokemon> UpdatePokemon(Pokemon pokemon);
}

