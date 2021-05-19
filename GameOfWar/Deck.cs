using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfWar
{
    // Values associated with each card, from lowest to highest
    //
    // By using an enum, this allows face cards to be compared with numerical values
    // in a simple and readable way.
    // Making it public allows outside classes to compare the card values
    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    // Suits for each card
    //
    // Used for assigning names to cards on initialization
    public enum CardSuit
    {
        Clubs,
        Spades,
        Diamonds,
        Hearts
    }

    // struct Card
    //
    // Represents a single playing card
    public struct Card
    {
        public Card(CardValue value, CardSuit suit)
        {
            m_value = value;
            m_suit = suit;
        }

        // Card values/ranks must be viewable, but not editable
        private CardValue m_value;
        public CardValue Value
        {
            get { return m_value; }
        }

        // Card suits must be viewable, but not editable
        private CardSuit m_suit;
        public CardSuit Suit
        {
            get { return m_suit; }
        }

        public override string ToString()
        {
            return $"{m_value} of {m_suit}";
        }
    }

    class Deck
    {
        // Constructor
        //
        // Fills the deck with the standard playing cards, each suit sorted by rank ascending
        public Deck()
        {
            m_cards = new List<Card>();

            // Generate iterable arrays consisting of each suit and value
            CardSuit[] suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            CardValue[] values = (CardValue[])Enum.GetValues(typeof(CardValue));

            // Note: I used LINQ syntax here specifically because it was mentioned in the
            // job description. Personally, I would prefer nested loops unless told otherwise.
            m_cards.AddRange(
                from CardSuit suit in suits
                from CardValue value in values
                let card = new Card(value, suit)
                select card
            );
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
        // param out card: Card to draw if the deck has remaining cards
        // returns: true if card was successfully drawn
        //          false if the deck is empty
        public bool DrawCard(out Card? card)
        {
            bool cardsRemaining = false;

            // We can't draw from an empty deck
            if (m_cards.Count > 0)
            {
                // Drawn cards are removed from the deck itself
                card = m_cards[0];
                m_cards.RemoveAt(0);
                cardsRemaining = true;
            }
            else
            {
                card = null;
            }

            return cardsRemaining;
        }

        public void AddRange(System.Collections.Generic.IEnumerable<Card> cards)
        {
            m_cards.AddRange(cards);
        }

        // Split
        //
        // Takes the first half of m_cards, removes it from the original deck.
        // Then returns the new deck as a separate entity from the first deck.
        // returns: A new Deck object, containing only the first half of the
        //          original deck.
        public Deck Split()
        {
            Deck secondDeck = new Deck();
            int halfDeck = m_cards.Count / 2;
            
            // The "Taken" top half must be removed from the m_deck
            secondDeck.m_cards = m_cards.Take(halfDeck).ToList();
            m_cards = m_cards.Skip(halfDeck).ToList();

            return secondDeck;
        }

        // Mainly for debugging
        public override string ToString()
        {
            string deckString = "";

            foreach (Card card in m_cards)
            {
                deckString += $"{card.ToString()}\n";
            }

            return deckString;
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
