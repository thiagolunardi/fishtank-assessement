using System;
namespace FishTank.Pumps
{
    public class SmallAirPump
    {
        private readonly Random _rnd = new Random();
        public Bubble[] PumpAir()
        {
            var x = _rnd.Next(5, 10);
            var bubbles = new Bubble[x];

            for (var a = 0; a < x; a++)
                bubbles[a] = (Bubble)_rnd.Next(1, 3);

            return bubbles;
        }
    }
}