using System;
using System.IO;
using System.Linq;

namespace Day1
{
    /// <summary>
    /// During the second Go / No Go poll, the Elf in charge of the Rocket Equation Double-Checker stops the launch sequence.
    /// Apparently, you forgot to include additional fuel for the fuel you just added
    /// 
    /// Fuel itself requires fuel just like a module - take its mass, divide by three, round down, and subtract 2. However,
    /// that fuel also requires fuel, and that fuel requires fuel, and so on.Any mass that would require negative fuel should
    /// instead be treated as if it requires zero fuel; the remaining mass, if any, is instead handled by wishing really hard,
    /// which has no mass and is outside the scope of this calculation.
    /// 
    /// So, for each module mass, calculate its fuel and add it to the total. Then, treat the fuel amount you just calculated
    /// as the input mass and repeat the process, continuing until a fuel requirement is zero or negative
    /// 
    /// What is the sum of the fuel requirements for all of the modules on your spacecraft?
    /// </summary>
    internal class Part2
    {
        public static void CalculateTotalFuelRequired()
        {
            var moduleMasses = File.ReadAllLines("input.txt").Select(int.Parse);
            var fuelRequired = moduleMasses.Sum(GetFuelRequired);
            Console.WriteLine("Fuel Required: {0}", fuelRequired);
        }

        /// <summary>
        /// Fuel required to launch a given module is based on its mass.
        /// Specifically, to find the fuel required for a module, take its mass, divide by three, round down, and subtract 2.
        ///
        /// However, that fuel also requires fuel, and that fuel requires fuel, and so on. Any mass that would require negative
        /// fuel should instead be treated as if it requires zero fuel.
        ///
        /// This function will recursively call itself to calculate the fuel required for the fuel values it returns.
        /// </summary>
        /// <param name="mass">Mass of a given module</param>
        /// <returns>Fuel required to launch the module</returns>
        private static int GetFuelRequired(int mass)
        {
            var initialFuelCalculation = decimal.ToInt32(Math.Floor(mass / 3m)) - 2;
            if (initialFuelCalculation > 0)
            {
                var additionalFuelRequired = GetFuelRequired(initialFuelCalculation);
                return initialFuelCalculation + additionalFuelRequired;
            }

            return 0;
        }
    }
}
