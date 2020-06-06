using System;
namespace FishTank.Fishes
{
    public class Fish : Animal
    {
        public Fish(AnimalSize size) : base(size)
        {
        }

        public override bool TryEat(Animal animal)
        {
            base.TryEat(animal);

            if (animal is Fish fish && fish.Size <= Size)
            {
                fish.IsDead = true;
                return true;
            }

            if (animal is Crab crab && crab.Size < Size)
            {
                crab.IsDead = true;
                return false;
            }

            return false;
        }
    }
}