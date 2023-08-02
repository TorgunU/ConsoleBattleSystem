using ConsoleApp1.Fabrics;
using ConsoleApp1.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CombatField
    {
        private CombatSystem _combatSystem;
        private UnitFactory _factory;

        public CombatField()
        {
            _combatSystem = new CombatSystem();
            _factory = new DefualtUnitFactory();
        }

        public void RunDuel()
        {
            Unit firstUnit = _factory.FactoryUnit();
            Unit secondUnit = _factory.FactoryUnit();

            while (IsOneUnitAlive(firstUnit, secondUnit))
            {
                PrintUnitsStats(firstUnit, secondUnit);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Атакует первый боец...");
                _combatSystem.CalculateAttack(firstUnit, secondUnit);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Атакует второй боец...");
                _combatSystem.CalculateAttack(secondUnit, firstUnit);

                Console.ForegroundColor = ConsoleColor.White;
            }

            PrintResults(firstUnit, secondUnit);

            Console.ReadKey();
        }

        private void PrintUnitsStats(params Unit[] units)
        {
            if (units.Length == 0)
                return;

            foreach (var unit in units)
            {
                unit.PrintStats();
                Console.WriteLine();
            }
        }

        private bool IsOneUnitAlive(params Unit[] units)
        {
            if (units.Length == 0)
                return false;

            foreach (Unit unit in units)
            {
                if(unit.HealthPoints <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void PrintResults(params Unit[] units)
        {
            Console.WriteLine("Бой закончен!");

            PrintUnitsStats(units);
        }
    }
}