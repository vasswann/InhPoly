using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal class Pidgey : Pokemon
    {
        public Pidgey(string nickname)
            : base(nickname, ElementType.Wind)
        {
        }

        public override string SpeciesName
        {
            get
            {
                return "Pidgey";
            }
        }
    }
}
