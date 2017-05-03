using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PokemonDeck.Models
{
    public class Pokemon
    {
        public int PokemonID { get; set; }
        public int Level { get; set; }
        public string Element { get; set; }
        public string Name { get; set; }

        public Pokedex Pokedex { get; set; }
        public int PokedexId { get; set; }

    }
}