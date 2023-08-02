using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConsoleApp1.Units
{
    public class DefaultUnit : Unit
    {
        public DefaultUnit() : base() { }
        public DefaultUnit(Fraction fraction) : base(fraction) { }

        public override int Attack()
        {
            return AttackValue;
        }

        public override void TakeDamage(int damage)
        {
            HealthPoints -= damage;

            if (HealthPoints <= 0)
            {
                Console.WriteLine("Юнит умер!");
            }
        }

        public override void AddEffect(Effect effect)
        {
            Effects.Add(effect);
            ApplyEffect(effect);
        }

        public override void ReduceEffectsAtOne()
        {
            List<Effect> uploadedEffects = new List<Effect>(Effects);

            foreach (Effect effect in Effects)
            {
                effect.DecreaseDurationAtOne();

                if (effect.Duration <= 0)
                {
                    RevertEffect(effect);
                    uploadedEffects.Remove(effect);
                }
            }

            Effects = uploadedEffects;
        }

        protected override void ApplyEffect(Effect effect)
        {
            AttackValue += effect.ApplyAttackEffect(AttackValue);
            DefenceValue += effect.ApplyDefenceEffect(DefenceValue);
        }

        protected override void RevertEffect(Effect effect)
        {
            AttackValue -= effect.RevertAttackEffect();
            DefenceValue -= effect.RevertDefenceEffect();
        }
    }
}