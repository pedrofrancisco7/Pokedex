using System;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;
using Pokedex.Service.Interfaces;

namespace Pokedex.Service.Services
{
    public class PokemonService : ServiceBase<Pokemon>, IPokemonService
    {
        private readonly IRepositoryBase<Pokemon> _repositoryBase;
        private readonly IPokemonRepository _pokemonRepository;
        public PokemonService(IRepositoryBase<Pokemon> repositoryBase,
                              IPokemonRepository pokemonRepository) : base(repositoryBase)
        {
            _repositoryBase = repositoryBase;
            _pokemonRepository = pokemonRepository;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonByNumero(int numero)
        {
            return await _pokemonRepository.GetPokemonByNumero(numero);
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByNome(string nome)
        {
            return await _pokemonRepository.GetPokemonsByNome(nome);
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByTipo(string tipo)
        {
            return await _pokemonRepository.GetPokemonsByTipo(tipo);
        }

        public async Task<Pokemon> UpdatePokemon(Pokemon pokemon)
        {
            return await _pokemonRepository.UpdatePokemon(pokemon);
        }
    }
}

