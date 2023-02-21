using System;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Data.Context;
using Pokedex.Data.Interfaces;
using Pokedex.Data.Repositories;
using Pokedex.Domain.Interfaces;
using Pokedex.Service.Interfaces;
using Pokedex.Service.Services;

namespace Pokedex.IoC.DependencyInjection;

public class Bindings
{
    public static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
        serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        serviceCollection.AddScoped<IPokemonRepository, PokemonRepository>();
        serviceCollection.AddScoped<IPokemonService, PokemonService>();

        serviceCollection.AddScoped(typeof(IDbContext), typeof(DbContext));
    }
}

