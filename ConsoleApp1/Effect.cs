using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Effect
    {
        public readonly double AttackCoefficient;
        public readonly double DefenceCoefficient;

        public double AttackEffect;
        public double DefenceEffect;

        public int Duration { get; protected set; }

        public Effect()
        {
            AttackCoefficient = 1;
            DefenceCoefficient = 1;
            Duration = 1;
        }

        public Effect(double attackCoefficient, double defenceCoefficient, int duration)
        {
            AttackCoefficient = attackCoefficient;
            DefenceCoefficient = defenceCoefficient;
            Duration = duration;
        }

        public abstract int ApplyAttackEffect(int unitAttackValue);
        public abstract int ApplyDefenceEffect(int unitDefenceValue);
        public abstract int RevertAttackEffect();
        public abstract int RevertDefenceEffect();
        public abstract void DecreaseDurationAtOne();
    }
}