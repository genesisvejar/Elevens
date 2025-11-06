
using System;

namespace CardDeck

{
class Program {


        static void Main(string[] args)
        {
            
            // Create a new card
            Card aCard = new Card(Rank.Eight, Suit.Hearts);

            // Display card rank and suit
            Console.WriteLine($"Card: {aCard.Rank} of {aCard.Suit}");

            Console.WriteLine($"Face Up: {aCard.FaceUp}");

            // Flip the card over
            aCard.FlipOver();

            Console.WriteLine($"\nAfter flipping: \n");

            // Show card's rank and suit again
            Console.WriteLine($"Card: {aCard.Rank} of {aCard.Suit}");

            Console.WriteLine($"Face Up: {aCard.FaceUp}");


            // Create a new deck
            Deck aDeck = new Deck();

            Console.WriteLine($"\nNew deck created.");

            // Count the cards in the deck
            Console.WriteLine($"Cards in deck: {aDeck.Cards.Count}");

            // Shuffle the deck
            aDeck.Shuffle();

            Console.WriteLine("\nDeck shuffled.\n");


            // Take the top card from the deck
            Card topCard = aDeck.TakeTopCard();

            if (topCard != null)
            {
                Console.WriteLine($"Took the top card: {topCard.Rank} of {topCard.Suit}");
            }
            else
            {
                Console.WriteLine("The deck is empty.");
            }
            Console.WriteLine($"\nCards left in deck: {aDeck.Cards.Count}\n");


            // Cut the deck
            int cutIndex = aDeck.Cards.Count / 3;

            aDeck.Cut(cutIndex);

            Console.WriteLine($"Deck cut at index {cutIndex}.");
            



        }

}

}