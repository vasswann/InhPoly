using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal class Charmander : Pokemon
    {
        public Charmander(string nickname) : base(nickname, ElementType.Fire)
        {
        }

        public override string SpeciesName
        {
            get
            {
                return "Charmander";
            }
        }
    }
}
