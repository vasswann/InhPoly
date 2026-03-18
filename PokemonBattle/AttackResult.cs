using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal class AttackResult
    {
        public ElementType AttackType { get; set; }
        public AttackOutcomeType OutcomeType { get; set; }
        public int Amount { get; set; }
        public int StreakCount { get; set; }
    }
}