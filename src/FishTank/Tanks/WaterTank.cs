using System;
using System.Collections.Generic;
using System.Linq;
using FishTank.Fishes;
using FishTank.Pumps;

namespace FishTank.Tanks
{
    public class WaterTank
    {
        private readonly object AirPump;

        public List<Animal> Animals { get; set; }

        public WaterTank()
        {
            AirPump = null;
            Animals = new List<Animal>();
        }

        public WaterTank(SmallAirPump pump) : this()
        {
            AirPump = pump;
        }

        public WaterTank(LargeAirPump pump) : this()
        {
            AirPump = pump;
        }

        public void StartTheBattleOfLife()
        {
            Console.WriteLine("Start The Battle Of Life");
            Console.WriteLine($"  Animals: {Animals.Count}");

            Random rnd = new Random();

            while (Animals.Count(a => !a.IsDead) > 1)
            {
                if (AirPump is null)
                {
                    foreach (var animal in Animals)
                        animal.IsDead = true;
                }

                var oxygen = 0;

                Console.Write("  Pumping air...");
                if (AirPump is SmallAirPump small)
                {
                    var bubbles = small.PumpAir();
                    oxygen = bubbles.Sum(x => (int)x);
                    Console.Write($" {bubbles.Length} bubbles... Glub glub.");
                    Console.WriteLine();
                }
                else if (AirPump is LargeAirPump large)
                {
                    var bubbles = large.PumpAir();
                    oxygen = bubbles.Sum(x => (int)x);
                    Console.Write($" {bubbles.Length} bubbles... Glub glub glub.");
                    Console.WriteLine();
                }

                foreach (var animal in Animals)
                {
                    if (animal.IsDead) continue;
                    oxygen -= (int)animal.Size;
                }

                if (oxygen <= 0)
                {
                    foreach (var animal in Animals)
                        animal.IsDead = true;

                    Console.WriteLine($"  Not enough oxygen!");
                    break;
                }

                var livingAnimals = Animals.Where(x => !x.IsDead).ToList();

                // predator                
                var fishA = livingAnimals[rnd.Next(livingAnimals.Count)];
                livingAnimals.Remove(fishA);
                // prey
                var fishB = livingAnimals[rnd.Next(livingAnimals.Count)];

                if (fishA != fishB && fishA.TryEat(fishB))
                {
                    Console.WriteLine($"  A {fishA.Size} {fishA.GetType().Name} ate a {fishB.Size} {fishB.GetType().Name} !");
                    Console.WriteLine($"  {Animals.Count} animals");
                }
                else
                {
                    Console.WriteLine("  No one dies today.");
                }
            }

            Console.WriteLine();
            if (Animals.Count(a => !a.IsDead) == 1)
            {
                var king = Animals.Single(a => !a.IsDead);
                Console.WriteLine($"=> We have the new Tank King!");
                Console.WriteLine($"   Habemus {king.Size} {king.GetType().Name}!");
            }
            else
            {
                Console.WriteLine("=> All animals are DEAD!");
            }
        }
    }
}