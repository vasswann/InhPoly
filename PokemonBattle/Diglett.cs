using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal class Diglett : Pokemon
    {
        public Diglett(string nickname)
            : base(nickname, ElementType.Earth)
        {
        }

        public override string SpeciesName
        {
            get
            {
                return "Diglett";
            }
        }
    }
}