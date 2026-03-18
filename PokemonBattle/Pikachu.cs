using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal class Pikachu : Pokemon
    {
        public Pikachu(string nickname)
            : base(nickname, ElementType.Electric)
        {
        }

        public override string SpeciesName
        {
            get
            {
                return "Pikachu";
            }
        }
    }
}