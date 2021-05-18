using System;

namespace GameOfWar
{
    class Program
    {
        static void Split()
        {
            Deck deck1 = new Deck();
            Deck deck2 = deck1.Split();

            Console.WriteLine("Deck 1:");
            deck1.Shuffle();
            Console.WriteLine(deck1.ToString());

            Console.WriteLine("Deck 2:");
            Console.WriteLine(deck2.ToString());
        }

        static void PrintShuffle()
        {
            Deck mydeck = new Deck();
            mydeck.ToString();
            Console.WriteLine("-------------------");
            mydeck.Shuffle();
            mydeck.ToString();
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
            GameOfWar game = new GameOfWar();
            game.RunGame();
        }
    }
}
