using System;
namespace FishTank.Fishes
{
    public class Crab : Animal
    {
        public Crab(AnimalSize size) : base(size)
        {
        }

        public override bool TryEat(Animal animal)
        {
            base.TryEat(animal);

            if (animal is Fish fish && ((int)fish.Size - 1) <= (int)Size)
            {
                fish.IsDead = true;
                return true;
            }

            if (animal is Crab crab && crab.Size <= Size)
            {
                crab.IsDead = true;
                return true;
            }

            return false;
        }
    }
}