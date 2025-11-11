
/*    ElevensGame Class
---------------------------
- deck : Deck;
- board : Board;
- GetCardValue(Card) : int;
- DoesPairSum11(Card, Card) : bool;
- IsAJQKCombo(Card, Card, Card) : bool;
- IsThereValidMovesLeft() : bool;
- PairRemoval() : void;
- JKQRemoval() : void;
- JKQRemoval() : void;
----------------------------
+ ElevensGame ();
+ Play();



// updates

/*
ElevensGameClass UML and its implementation

*/



using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using CardDeck;

public class ElevensGame
{

    //fields 

    private Deck deck;

    private Board board;

    public ElevensGame()
    {
        deck = new Deck(); // here, you create the deck that board class uses as a reference on the constructor
        deck.Shuffle();
        board = new Board(deck); // and create that board with 9 cards and pass the deck above.
    }
    //methods
    private int GetCardValue(Card card)
    {
        switch (card.Rank)
        {
            case Rank.Ace: return 1;
            case Rank.Two: return 2;
            case Rank.Three: return 3;
            case Rank.Four: return 4;
            case Rank.Five: return 5;
            case Rank.Six: return 6;
            case Rank.Seven: return 7;
            case Rank.Eight: return 8;
            case Rank.Nine: return 9;
            case Rank.Ten: return 10;
            case Rank.Jack: return 11;
            case Rank.Queen: return 12;
            case Rank.King: return 13;
            default: return 0;
        }
    }

    private bool DoesPairSum11(Card card1, Card card2)
    {

        //put false first
        if (card1 == null || card2 == null)
        {
            return false;
        }

        int cardValue1 = GetCardValue(card1);
        int cardValue2 = GetCardValue(card2);

        return (cardValue1 + cardValue2 == 11);
    }


    private bool IsAJQKCombo(Card card1, Card card2, Card card3)
    {
        if (card1 == null || card2 == null || card3 == null)
        {
            return false;

        }

        //list of Rank (the card Rank from the enum) and creates a new list of rank
        List<Rank> ranks = new List<Rank>
        {
            card1.Rank,
            card2.Rank,
            card3.Rank,

        };

        //then you use parameter you got from the function and use it rank from the property
        //finally return a bool using the ranks list and contains method.
        //if they are all true, then the expression is true, if not it's false.

        return ranks.Contains(Rank.Jack) && ranks.Contains(Rank.Queen) && ranks.Contains(Rank.King);
        // contains method traverses the entire list to check if the rank is there, so order doesn't matter

    }

    //board is an array of Cards
    private bool IsThereValidMovesLeft()
    {


        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 9; j++)
            { //the two loops and its +1 is so that there's one 1 comparison with each pair
                // also rememeber i =0, then you enter the second loop j =1..8, it goes out
                // then goes back to i =1 and then j=2..8 and so on and so forth.

                Card card1 = board.GetACard(i); // create a card and take it from the board that we created on this class
                Card card2 = board.GetACard(j);

                //gonna be the same as the ones on the loop cause that's we're transversing
                if (card1 != null && card2 != null)
                {
                    if (DoesPairSum11(card1, card2))
                    {
                        return true;
                    }
                }
            }


        }


        for (int i = 0; i < 9; i++)
        {
            for (int j = i + 1; j < 9; j++)
            {
                for (int k = j + 1; k < 9; k++) // you use only j cause j and i are already together
                {

                    Card card1 = board.GetACard(i);
                    Card card2 = board.GetACard(j);
                    Card card3 = board.GetACard(k);

                    if (card1 != null && card2 != null && card3 != null)
                    {
                        if (IsAJQKCombo(card1, card2, card3))
                        {
                            return true;
                        }

                    }

                }
            }
        }

        return false;

    }



    private void PairRemoval()
    {
        Console.WriteLine("Enter card position 1: ");
        int position1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter card position 2: ");
        int position2 = int.Parse(Console.ReadLine());

        Card card1 = board.GetACard(position1);
        Card card2 = board.GetACard(position2);

        if (DoesPairSum11(card1, card2))
        {
            List<int> positions = new List<int> { position1, position2 };
            board.ReplaceCards(positions);
            Console.WriteLine("Pair removed");

        }
        else // we might remove
        {

            Console.WriteLine("Cards dont sum to 11");
        }
    }

    private void JKQRemoval()
    {
        Console.WriteLine("Enter position 1: ");
        int position1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter position 2: ");
        int position2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter position 3: ");
        int position3 = int.Parse(Console.ReadLine());

        Card card1 = board.GetACard(position1);
        Card card2 = board.GetACard(position2);
        Card card3 = board.GetACard(position3);

        if (IsAJQKCombo(card1, card2, card3))
        {
            List<int> positions = new List<int> { position1, position2, position3 };
            board.ReplaceCards(positions);
            Console.WriteLine("JQK Combo removed");
        }
        else
        {
            Console.WriteLine("Card don't make the JQK combo");
        }


    }

    public void Play()
    {

        while (IsThereValidMovesLeft())
        {
            Console.WriteLine("Welcome to the Elevens Game");

            board.DisplayBoard();

            Console.WriteLine("Select an option (1-3)");
            Console.WriteLine("1.Remove a pair that sums to 11");
            Console.WriteLine("2. Remove a JQK triplet");
            Console.WriteLine("3. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PairRemoval();
                    break;
                case "2":
                    JKQRemoval();
                    break;
                case "3":
                    Console.WriteLine("Thanks for playing the Elevens game!");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Enter 1, 2 or 3");
                    break;
            }

        }

        if (board.IsBoardEmpty())
        {
            Console.WriteLine("You won! The board and the deck are empty");
        }
        else
        {

            Console.WriteLine("Game over! There's no more valid moves left :(");
        }
    }


}

