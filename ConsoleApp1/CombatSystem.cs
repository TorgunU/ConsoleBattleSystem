using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class CombatSystem
    {
        public void CalculateAttack(Unit attacker, Unit defender)
        {
            Effect attackerEffect = GetEffectFractionAttack(attacker.Fraction, defender.Fraction);

            attacker.AddEffect(attackerEffect);

            defender.TakeDamage(attacker.Attack());

            attacker.ReduceEffectsAtOne();
        }

        private Effect GetEffectFractionAttack(Fraction attackerFraction, Fraction defenderFraction)
        {
            switch (defenderFraction)
            {
                case Fraction.Neutral:
                    return new Debuff();

                case Fraction.Evil:
                    if (IsAllyAttacking(attackerFraction, defenderFraction))
                    {
                        return new Debuff(-0.5, 0, 1);
                    }

                    return new Buff(0.5, 0, 1);

                case Fraction.Good:
                    if (IsAllyAttacking(attackerFraction, defenderFraction))
                    {
                        return new Debuff(-0.5, 0, 1);
                    }

                    return new Buff(0.5, 0, 1);

                case Fraction.SemiEvil:
                    if (IsAllyAttacking(attackerFraction, defenderFraction))
                    {
                        return new Debuff(0.25, 0, 1);
                    }

                    return new Buff(0.25, 0, 1);

                case Fraction.SemiGood:
                    if (IsAllyAttacking(attackerFraction, defenderFraction))
                    {
                        return new Debuff(-0.25, 0, 1);
                    }

                    return new Debuff(-0.25, 0, 1);

                default:
                    throw new Exception("Фракции врага не существует!");
            }
        }

        private bool IsAllyAttacking(Fraction attackerFraction, 
            Fraction defenderFraction)
        {
            return attackerFraction == defenderFraction;
        }
    }
}