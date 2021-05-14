using System;
using System.Collections.Generic;
using System.Text;

// Each player gets dealt half the deck, 26 cards, and the cards are put face down
// in a stack in front of the players.
//
// Both players turn their top card face up at the same time. The person with the
// higher card wins that draw, and takes both the cards. They are put to the side
// to form a new stack, which the player can use when he finishes his current stack.
//
// If both players draw a card of the same rank, e.g. they both draw 8s, then there's
// a war. The face up cards are left on the table and each player puts three cards face
// down on the table, and then puts one card face up. The face up card determines who
// wins the war and gets all 10 cards that are on the table at this point. If the face
// up card is again the same rank, then the war goes on, three more face down, one face up etc.
//
// First player to finish all their cards loses the game.
//
// If a player finishes their cards during a war without having enough cards to finish the
// war then they lose immediately.

namespace GameOfWar
{
    class GameOfWar
    {
    }
}
