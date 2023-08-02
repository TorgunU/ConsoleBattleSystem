using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Unit
    {
        protected readonly int MinDefenceValue;
        protected readonly int MaxDefenceValue;

        protected static Random Random = new Random();
        private string _name;
        private int _healthPoints;
        private int _attackValue;
        private int _defenceValue;

        public virtual List<Effect> Effects { get; protected set; }
        public virtual Fraction Fraction { get; protected set; }
        public virtual int HealthPoints { get => _healthPoints; protected set => _healthPoints = value; }
        public virtual int AttackValue { get => _attackValue; protected set => _attackValue = value; }
        public virtual int DefenceValue { get => _defenceValue; protected set => _defenceValue = value; }
        public virtual string Name { get => _name; protected set => _name = value; }

        public Unit()
        {
            Effects = new List<Effect>();

            MinDefenceValue = 0;
            MaxDefenceValue = 100;

            _healthPoints = Random.Next(25, 150);
            _attackValue = Random.Next(5, 25);
            _defenceValue = Random.Next(5, 25);
            _name = Random.Next(0, 150).ToString();

            Fraction = (Fraction)Random.Next(0, 5);
        }

        public Unit (Fraction fraction) : this()
        {
            Fraction = fraction;
        }

        public abstract int Attack();
        public abstract void TakeDamage(int damage);

        public virtual void AddEffect(Effect effect)
        {
            Effects.Add(effect);
            ApplyEffect(effect);
        }

        public virtual void ReduceEffectsAtOne()
        {
            foreach (Effect effect in Effects)
            {
                effect.DecreaseDurationAtOne();

                if (effect.Duration <= 0)
                {
                    RevertEffect(effect);
                }
            }
        }

        public virtual void PrintStats()
        {
            Console.WriteLine($"[Name: {Name}]. Health {HealthPoints}. " +
                $"Attack: {AttackValue}, Defence: {DefenceValue}, " +
                $"Fraction: {Fraction}");
        }

        protected abstract void ApplyEffect(Effect effect);
        protected abstract void RevertEffect(Effect effect);
    }
}