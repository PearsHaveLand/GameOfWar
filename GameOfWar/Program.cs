using System;

namespace GameOfWar
{
    class Program
    {
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
            Deck.Card? card = mydeck.DrawCard();
            while (card is Deck.Card valueOfCard)
            {
                Console.WriteLine($"{valueOfCard.name}");
                card = mydeck.DrawCard();
            }

            if (!(card is Deck.Card cardVal))
            {
                Console.WriteLine("End of the deck");
            }
        }

        static void Main(string[] args)
        {
            Draw();
        }
    }
}
