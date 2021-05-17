using System;

namespace GameOfWar
{
    class Program
    {
        static void Split()
        {
            Deck deck1 = new Deck();
            deck1.Populate();
            Deck deck2 = deck1.Split();

            Console.WriteLine("Deck 1:");
            deck1.Shuffle();
            deck1.PrintCards();

            Console.WriteLine("Deck 2:");
            deck2.PrintCards();
        }

        static void PrintShuffle()
        {
            Deck mydeck = new Deck();
            mydeck.PrintCards();
            Console.WriteLine("-------------------");
            mydeck.Shuffle();
            mydeck.PrintCards();
        }

        static void Draw()
        {
            Deck mydeck = new Deck();
            Card? card = mydeck.DrawCard();
            while (card is Card valueOfCard)
            {
                Console.WriteLine(valueOfCard.ToString());
                card = mydeck.DrawCard();
            }

            if (!(card is Card cardVal))
            {
                Console.WriteLine("End of the deck");
            }
        }

        static void Main(string[] args)
        {
            Split();
        }
    }
}
