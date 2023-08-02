using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class UnitFactory
    {
        public abstract Unit FactoryUnit();

        public abstract Unit FactoryUnit(Fraction fraction);
    }
}
