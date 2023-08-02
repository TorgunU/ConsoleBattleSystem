using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Debuff : Effect
    {
        public Debuff(double attackCoefficient, double defenceCoefficient, int duration) : base(attackCoefficient, defenceCoefficient, duration)
        {
        }

        public Debuff()
        {
        }

        public override int ApplyAttackEffect(int unitAttackValue)
        {
            AttackEffect = (int)(AttackCoefficient * unitAttackValue);
            return (int)AttackEffect;
        }

        public override int ApplyDefenceEffect(int unitDefenceValue)
        {
            DefenceEffect = (int)(DefenceCoefficient * unitDefenceValue);
            return (int)DefenceEffect;
        }

        public override int RevertAttackEffect()
        {
            return (int)(AttackEffect);
        }

        public override int RevertDefenceEffect()
        {
            return (int)Math.Abs(DefenceEffect);
        }

        public override void DecreaseDurationAtOne()
        {
            --Duration;
        }
    }
}