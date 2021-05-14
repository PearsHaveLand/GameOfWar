using System;

namespace GameOfWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck mydeck = new Deck();
            mydeck.PrintCards();
            Console.WriteLine("-------------------");
            mydeck.Shuffle();
            mydeck.PrintCards();
        }
    }
}
