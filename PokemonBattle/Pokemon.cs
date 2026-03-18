using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattle
{
    internal abstract class Pokemon
    {

        protected const int BaseHp = 1000;
        protected const int BaseShield = 40;
        protected const int BaseAttackDamage = 50;
        protected const int BaseShieldRecharge = 40;

        private int _currentStreakCount;
        private AttackOutcomeType? _lastOutcomeType;
        public string Nickname { get; }
        public ElementType ElementType { get; }
        public int Hp { get; private set; }
        public int Shield { get; private set; }
        public bool IsFainted { get { return Hp <= 0; } }

        protected Pokemon(string nickname, ElementType elementType)
        {
            Nickname = nickname;
            ElementType = elementType;
            Hp = BaseHp;
            Shield = BaseShield;
            _currentStreakCount = 0;
            _lastOutcomeType = null;
        }

        public abstract string SpeciesName { get; }

        public void ReceiveDamage(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            if (Shield >= amount)
            {
                Shield -= amount;
            }
            else
            {
                int remainingDamage = amount - Shield;
                Shield = 0;
                Hp -= remainingDamage;

                if (Hp < 0)
                {
                    Hp = 0;
                }
            }
        }

        public void RestoreShield(int amount)
        {
            if (amount <= 0)
            {
                return;
            }

            Shield += amount;
        }

        protected ElementType ChooseRandomAttackType(Random random)
        {
            int numberOfElements = Enum.GetValues(typeof(ElementType)).Length;
            int randomIndex = random.Next(numberOfElements);

            return (ElementType)randomIndex;
        }

        protected void UpdateStreak(AttackOutcomeType currentOutcome)
        {
            if (_lastOutcomeType == currentOutcome)
            {
                _currentStreakCount++;
            }
            else
            {
                _currentStreakCount = 1;
            }

            _lastOutcomeType = currentOutcome;
        }

        protected int CalculateStreakValue(int baseValue)
        {
            double value = baseValue;

            for (int i = 1; i < _currentStreakCount; i++)
            {
                value *= 1.5;
            }

            return (int)value;
        }

        public AttackResult PerformAttack(Pokemon target, Random random)
        {
            ElementType attackType = ChooseRandomAttackType(random);

            if (attackType == target.ElementType)
            {
                UpdateStreak(AttackOutcomeType.ShieldRecharge);

                int shieldRechargeAmount = CalculateStreakValue(BaseShieldRecharge);
                target.RestoreShield(shieldRechargeAmount);

                return new AttackResult
                {
                    AttackType = attackType,
                    OutcomeType = AttackOutcomeType.ShieldRecharge,
                    Amount = shieldRechargeAmount,
                    StreakCount = CurrentStreakCount
                };
            }
            else
            {
                UpdateStreak(AttackOutcomeType.Damage);

                int damageAmount = CalculateStreakValue(BaseAttackDamage);
                target.ReceiveDamage(damageAmount);

                return new AttackResult
                {
                    AttackType = attackType,
                    OutcomeType = AttackOutcomeType.Damage,
                    Amount = damageAmount,
                    StreakCount = CurrentStreakCount
                };
            }
        }

        protected int CurrentStreakCount
        {
            get
            {
                return _currentStreakCount;
            }
        }
    }
}
