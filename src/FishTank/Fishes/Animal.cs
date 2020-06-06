using System;
namespace FishTank.Fishes
{
    public abstract class Animal
    {
        public Guid DNA { get; }
        public bool IsDead { get; set; }
        public AnimalSize Size { get; private set; }
        public virtual bool TryEat(Animal animal)
        {
            if (animal == null)
            {
                throw new ArgumentNullException(nameof(animal));
            }

            if (animal.IsDead)
            {
                return false;
            }

            Console.WriteLine($"  A {Size} {GetType().Name} tries to eat a {animal.Size} {animal.GetType().Name}.");

            return false;
        }

        protected Animal(AnimalSize size) =>
            (Size, DNA) = (size, Guid.NewGuid());

        public override bool Equals(object obj) =>
            obj is Animal animal &&
            DNA.Equals(animal.DNA);


        public override int GetHashCode() =>
            DNA.GetHashCode();

        public static bool operator !=(Animal left, Animal right) =>
            left.DNA != right?.DNA;

        public static bool operator ==(Animal left, Animal right) =>
            left.DNA == right?.DNA;
    }

    public enum AnimalSize
    {
        Tiny = 0,
        Small = 1,
        Medium = 2,
        Large = 3,
        Gigant = 4
    }
}