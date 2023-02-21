using System;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pokedex.Domain.Entities;

[Table("Pokemons")]
public class Pokemon
{
    public Pokemon()
    {
        Tipo = new List<string>();
        Stats = new List<Dictionary<string, int>>();
        Genero = new List<string>();
        Descricao = new Descricao();
        Habilidades = new List<string>();
        Fraquezas = new List<string>();
        Evolucoes = new List<Evolucao>();
    }


    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public int Numero { get; set; }
    public string? Nome { get; set; }
    public string? Forma { get; set; }
    
    public string Imagem { get; set; }
    public string? Url { get; set; }
    public List<string> Tipo { get; set; }
    public List<string> Fraquezas { get; set; }
    public List<Dictionary<string, int>> Stats { get; set; }
    public Descricao Descricao { get; set; }
    public string Altura { get; set; }
    public string Peso { get; set; }
    public List<string> Genero { get; set; }
    public string Categoria { get; set; }
    public List<string> Habilidades { get; set; }
    public List<Evolucao> Evolucoes { get; set; }
    public List<LevelEvolucao> LevelEvolucao { get; set; }

}

public class Descricao
{
    public string? VersaoX { get; set; }
    public string? VersaoY { get; set; }
}

public class Evolucao
{
    public Evolucao()
    {
        Tipo = new List<string>();
    }

    public string? Nome { get; set; }
    public string? Numero { get; set; }
    public List<string>? Tipo { get; set; }
}

public class LevelEvolucao
{
    public string? Versao { get; set; }    
    public string? Metodo { get; set; }
    public string? Level { get; set; }
}
