using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PokemonBattle
{
    internal class PokemonBattle
    {
        private Pokemon _firstPokemon;
        private Pokemon _secondPokemon;
        private Random _random;
        private int _delayMilliseconds;

        public PokemonBattle(Pokemon firstPokemon, Pokemon secondPokemon)
        {
            _firstPokemon = firstPokemon;
            _secondPokemon = secondPokemon;
            _random = new Random();
            _delayMilliseconds = 3000;
        }

        public void Start()
        {
            Pokemon attacker = _firstPokemon;
            Pokemon defender = _secondPokemon;
            int roundNumber = 1;

            Console.WriteLine("Let the Pokemon battle begin!");
            Console.WriteLine();
            ShowPokemonStatus();
            Pause();

            while (!attacker.IsFainted && !defender.IsFainted)
            {
                Console.WriteLine($"--- Round {roundNumber} ---");
                Console.WriteLine($"{attacker.Nickname} the {attacker.SpeciesName} attacks!");

                AttackResult result = attacker.PerformAttack(defender, _random);
                ShowAttackMessage(attacker, defender, result);

                ShowPokemonStatus();
                Pause();

                if (defender.IsFainted)
                {
                    Console.WriteLine($"{defender.Nickname} the {defender.SpeciesName} has fainted!");
                    Console.WriteLine($"{attacker.Nickname} the {attacker.SpeciesName} wins the battle!");
                    break;
                }

                Pokemon temp = attacker;
                attacker = defender;
                defender = temp;

                roundNumber++;
            }
        }

        private void ShowPokemonStatus()
        {
            Console.WriteLine($"{_firstPokemon.Nickname} the {_firstPokemon.SpeciesName} | HP: {_firstPokemon.Hp} | Shield: {_firstPokemon.Shield}");
            Console.WriteLine($"{_secondPokemon.Nickname} the {_secondPokemon.SpeciesName} | HP: {_secondPokemon.Hp} | Shield: {_secondPokemon.Shield}");
            Console.WriteLine();
        }

        private void Pause()
        {
            Thread.Sleep(_delayMilliseconds);
        }

        private void ShowAttackMessage(Pokemon attacker, Pokemon defender, AttackResult result)
        {
            Console.WriteLine($"{attacker.Nickname} the {attacker.SpeciesName} used {result.AttackType} attack!");

            if (result.OutcomeType == AttackOutcomeType.Damage)
            {
                Console.WriteLine("Successful attack!");
                Console.WriteLine($"Damage streak: {result.StreakCount}");
                Console.WriteLine($"{defender.Nickname} the {defender.SpeciesName} took {result.Amount} damage.");
            }
            else
            {
                Console.WriteLine($"The attack matched {defender.Nickname}'s element type.");
                Console.WriteLine("No damage was dealt.");
                Console.WriteLine($"Shield recharge streak: {result.StreakCount}");
                Console.WriteLine($"{defender.Nickname} the {defender.SpeciesName} restored {result.Amount} shield.");
            }

            Console.WriteLine();
        }
    }
}