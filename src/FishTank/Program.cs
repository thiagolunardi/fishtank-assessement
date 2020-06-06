using System.Collections.Generic;
using FishTank.Fishes;
using FishTank.Pumps;
using FishTank.Tanks;

namespace FishTank
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var large = new LargeAirPump();

            var tank = new WaterTank(large);

            var fishes = new List<Fish>();
            fishes.Add(new Fish(AnimalSize.Tiny));
            fishes.Add(new Fish(AnimalSize.Tiny));
            fishes.Add(new Fish(AnimalSize.Tiny));
            fishes.Add(new Fish(AnimalSize.Tiny));
            fishes.Add(new Fish(AnimalSize.Small));
            fishes.Add(new Fish(AnimalSize.Small));
            fishes.Add(new Fish(AnimalSize.Small));
            fishes.Add(new Fish(AnimalSize.Medium));
            fishes.Add(new Fish(AnimalSize.Medium));
            fishes.Add(new Fish(AnimalSize.Large));

            tank.Animals.AddRange(fishes);

            var crabs = new List<Crab>();
            crabs.Add(new Crab(AnimalSize.Small));
            crabs.Add(new Crab(AnimalSize.Medium));

            tank.Animals.AddRange(crabs);

            tank.StartTheBattleOfLife();
        }
    }
}
