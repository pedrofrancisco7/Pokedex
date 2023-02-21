using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Domain.Entities;
using Pokedex.Service.Interfaces;

namespace Pokedex.Application.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PokedexController : Controller
{
    private readonly IPokemonService _pokemonService;

    public PokedexController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPokemons()
    {
        try
        {
            var pokemons = await _pokemonService.SelectAsync();

            foreach (var pokemon in pokemons)
            {
                pokemon.Imagem = null;
            }

            return Json(pokemons);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonsByNumero(int numero)
    {
        try
        {
            var pokemons = await _pokemonService.GetPokemonByNumero(numero);

            return Json(pokemons);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonsByNome(string nome, bool ignoreImage = true)
    {
        try
        {
            var pokemons = await _pokemonService.GetPokemonsByNome(nome);

            if (ignoreImage)
            {
                foreach (var pokemon in pokemons)
                {
                    pokemon.Imagem = null;
                }
            }

            return Json(pokemons);
        }
        catch (Exception ex)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetPokemonsByTipo(string tipo, bool ignoreImage = true)
    {
        try
        {
            var pokemons = await _pokemonService.GetPokemonsByTipo(tipo);

            if (ignoreImage)
            {
                foreach (var pokemon in pokemons)
                {
                    pokemon.Imagem = null;
                }
            }

            return Json(pokemons);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePokemon([FromBody] Pokemon pokemon)
    {
        var t = ModelState;
        try
        {
            var result = await _pokemonService.UpdatePokemon(pokemon);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

}

