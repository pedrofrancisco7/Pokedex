using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;
using Pokedex.Data.Interfaces;
using Pokedex.Domain.Entities;
using Pokedex.Domain.Interfaces;

namespace Pokedex.Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IDbContext _dbContext;
        private readonly string _tabela;
        public PokemonRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            var type = typeof(Pokemon);
            _tabela = Utils.Utils.GetTableName(type);

        }

        public async Task<Pokemon> GetPokemonByNome(string nome)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Pokemon>(_tabela);

            var filter = Builders<Pokemon>.Filter.Regex(c => c.Nome, BsonRegularExpression.Create(new Regex(nome, RegexOptions.IgnoreCase)));

            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonByNumero(int numero)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Pokemon>(_tabela);

            return await collection.Find(new BsonDocument("Numero", numero)).ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByNome(string nome)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Pokemon>(_tabela);

            var filter = Builders<Pokemon>.Filter.Regex(c => c.Nome, BsonRegularExpression.Create(new Regex(nome, RegexOptions.IgnoreCase)));

            return await collection.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Pokemon>> GetPokemonsByTipo(string tipo)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Pokemon>(_tabela);

            var filter = Builders<Pokemon>.Filter.Regex(c => c.Tipo, BsonRegularExpression.Create(new Regex(tipo, RegexOptions.IgnoreCase)));

            return await collection.Find(filter).ToListAsync();
        }

        public async Task<Pokemon> UpdatePokemon(Pokemon pokemon)
        {
            var collection = _dbContext.GetDatabase().GetCollection<Pokemon>(_tabela);            

            var filter2 = Builders<Pokemon>.Filter.And(
                Builders<Pokemon>.Filter.Where(p => p.Numero == pokemon.Numero),
                //Builders<Pokemon>.Filter.Where(p => p.Nome.ToLower().Contains(pokemon.Nome.ToLower())),
                Builders<Pokemon>.Filter.Regex(c => c.Nome, BsonRegularExpression.Create(new Regex(pokemon.Nome, RegexOptions.IgnoreCase))),
                Builders<Pokemon>.Filter.Regex(c => c.Forma, BsonRegularExpression.Create(new Regex(pokemon.Forma, RegexOptions.IgnoreCase)))
                );


            var arrayUpdate = Builders<Pokemon>.Update.Set(c => c.Descricao.VersaoX, pokemon.Descricao.VersaoX)
                                                      .Set(c => c.Descricao.VersaoY, pokemon.Descricao.VersaoY)
                                                      .Set(c => c.Tipo, pokemon.Tipo)
                                                      .Set(c => c.Fraquezas, pokemon.Fraquezas)
                                                      .Set(c => c.Stats, pokemon.Stats)
                                                      .Set(c => c.Categoria, pokemon.Categoria)
                                                      .Set(c => c.LevelEvolucao, pokemon.LevelEvolucao);



            var retorno = await collection.UpdateOneAsync(filter2, arrayUpdate);

            return pokemon;



        }
    }
}

