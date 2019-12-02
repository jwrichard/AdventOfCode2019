using System;
using System.IO;
using System.Linq;

namespace Day1
{
    /// <summary>
    /// The Elves quickly load you into a spacecraft and prepare to launch.
    /// At the first Go / No Go poll, every Elf is Go until the Fuel Counter-Upper. They haven't determined the amount of fuel required yet.
    /// Fuel required to launch a given module is based on its mass. Specifically, to find the fuel required for a module, take its mass,
    /// divide by three, round down, and subtract 2.
    ///
    /// The Fuel Counter-Upper needs to know the total fuel requirement. To find it, individually calculate the fuel needed for the mass of each module
    /// (your puzzle input), then add together all the fuel values.
    /// 
    /// What is the sum of the fuel requirements for all of the modules on your spacecraft?
    /// </summary>
    internal class Part1
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
        /// </summary>
        /// <param name="mass">Mass of a given module</param>
        /// <returns>Fuel required to launch the module</returns>
        private static int GetFuelRequired(int mass)
        {
            return decimal.ToInt32(Math.Floor(mass / 3m)) - 2;
        }
    }
}
