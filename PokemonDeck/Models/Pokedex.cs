using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonDeck.Models
{
    public class Pokedex
    {
        public int PokedexID { get; set; }
        public string Name { get; set; }

        public List<Pokemon> Pokemon { get; set; }
    }
}