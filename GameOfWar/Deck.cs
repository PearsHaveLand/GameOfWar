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
        // Making it public allows outside classes to compare the card values
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
        private enum CardSuit
        {
            CLUBS,
            SPADES,
            DIAMONDS,
            HEARTS
        }

        public struct Card
        {
            public CardValue val;  // Value or "rank" of card, to be compared against other cards
            public string name;    // Display name for the card
        }
        
        // Constructor
        public Deck()
        {
            m_cards = new List<Card>();

            // Iterate through each suit
            foreach (CardSuit suit in (CardSuit[]) Enum.GetValues(typeof(CardSuit)))
            {
                // Iterate through each card value
                foreach (CardValue val in (CardValue[])Enum.GetValues(typeof(CardValue)))
                {
                    Card card;
                    card.val = val;

                    // Assign string for card rank
                    switch (val)
                    {
                        case CardValue.TWO:
                            card.name = "Two of ";
                            break;

                        case CardValue.THREE:
                            card.name = "Three of ";
                            break;

                        case CardValue.FOUR:
                            card.name = "Four of ";
                            break;

                        case CardValue.FIVE:
                            card.name = "Five of ";
                            break;

                        case CardValue.SIX:
                            card.name = "Six of ";
                            break;

                        case CardValue.SEVEN:
                            card.name = "Seven of ";
                            break;

                        case CardValue.EIGHT:
                            card.name = "Eight of ";
                            break;

                        case CardValue.NINE:
                            card.name = "Nine of ";
                            break;

                        case CardValue.TEN:
                            card.name = "Ten of ";
                            break;

                        case CardValue.JACK:
                            card.name = "Jack of ";
                            break;

                        case CardValue.QUEEN:
                            card.name = "Queen of ";
                            break;

                        case CardValue.KING:
                            card.name = "King of ";
                            break;

                        case CardValue.ACE:
                            card.name = "Ace of ";
                            break;

                        default:
                            card.name = "";
                            break;
                    }

                    // Assign string for card suit
                    switch (suit)
                    {
                        case CardSuit.CLUBS:
                            card.name += "Clubs";
                            break;

                        case CardSuit.SPADES:
                            card.name += "Spades";
                            break;

                        case CardSuit.DIAMONDS:
                            card.name += "Diamonds";
                            break;

                        case CardSuit.HEARTS:
                            card.name += "Hearts";
                            break;

                        default:
                            card.name = "";
                            break;
                    }

                    // Add only valid cards to the deck
                    // Revise after coming up with better way to deal with this
                    if (card.name != "")
                    {
                        m_cards.Add(card);
                    }
                }
            }
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

        // DrawCard
        //
        // Copies the card at index 0 (the "top" of the deck), and returns it.
        // returns: Copy of the "top" card of the deck if it exists, or
        //          null if the deck is empty
        public Card? DrawCard()
        {
            Card? card = null;

            // Check for empty deck
            if (m_cards.Count > 0)
            {
                // Copy the "top" of the deck, remove top
                card = m_cards[0];
                m_cards.RemoveAt(0);
            }

            return card;
        }

        // Mainly for debugging
        public void PrintCards()
        {
            foreach (Card card in m_cards)
            {
                Console.WriteLine($"{card.name}, {card.val}");
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
