using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfWar
{
    class Deck
    {
        // Values associated with each card, from lowest to highest
        //
        // By using an enum, this allows face cards to be compared with numerical values
        // in a simple and readable way.
        public enum CardValue
        {
            TWO,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGHT,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }
        
        // Suits for each card
        //
        // Used for assigning names to cards on initialization
        public enum CardSuit
        {
            CLUBS,
            SPADES,
            DIAMONDS,
            HEARTS
        }

        struct Card
        {
            CardValue val;  // Value or "rank" of card, to be compared against other cards
            string name;    // Display name for the card
        }
        
        // Constructor
        public Deck()
        {
            /*
             * Initialize each card
             * Add each card to deck
             */
        }

        // Shuffle
        // Takes the current deck and randomizes the location of each card
        public void Shuffle()
        {
            int cardCount = m_cards.Count;

            // Initialize random number generator
            Random randGenerator = new Random();
            
            // Randomized position for shuffling
            int randPos;

            for (int i = 0; i < cardCount; i++)
            {
                // Generate random position
                randPos = randGenerator.Next(cardCount);

                swapCardsAt(i, randPos);
            }
        }

        // swapCardsAt
        // Given two card locations, switches their location in the deck
        // 
        // param first - the position of the first card to be switched
        // param second - the position of the second card to be switched
        private void swapCardsAt(int first, int second)
        {
            int cardCount = m_cards.Count;

            // Only perform the operation if given valid positions, and the positions
            // are NOT the same
            if (first < cardCount && second < cardCount && first != second)
            {
                // Placeholder for first card when swapping
                Card temp;
                temp = m_cards[first];

                // Swap cards to each other's positions
                m_cards[first] = m_cards[second];
                m_cards[second] = temp;
            }
        }

        private List<Card> m_cards;  // Deck of cards for shuffling, dealing, etc.
    }
}
