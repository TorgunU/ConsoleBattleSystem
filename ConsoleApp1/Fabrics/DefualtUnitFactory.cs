using ConsoleApp1.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Fabrics
{
    internal class DefualtUnitFactory : UnitFactory
    {
        public override Unit FactoryUnit()
        {
            return new DefaultUnit();
        }

        public override Unit FactoryUnit(Fraction fraction)
        {
            return new DefaultUnit(fraction);
        }
    }
}
