using System.Threading.Tasks.Dataflow;
using CardDeck;

/*   Board ClassUML 
-----------------------
- board :  Card [];
- deck : Deck ;
-----------------------
+ Board (Deck);
+ Deal9Cards() : void;
+ DisplayBoard() : void;
+ GetACard() : Card;
+ ReplaceCards(List <int>) : void;
+ IsBoardEmpty() : bool;


*/


public class Board
{
    //fields
    private Card[] board;
    private Deck deck;


    //constructor
    public Board(Deck aDeck) // a Deck object is passed so the class
    //create one and then have two decks 
    {
        deck = aDeck;
        board = new Card[9];
        Deal9Cards();
    }


    //methods

    private void Deal9Cards()
    {
        for (int i = 0; i < 9; i++)
        {
            board[i] = deck.TakeTopCard();

            if (board[i] != null)

            {
                board[i].FlipOver();
            }
        }

    }

    public void DisplayBoard()
    {

        for (int i = 0; i < 9; i++)
        {
            if (board[i] != null)
            {
                Console.WriteLine($"{i}. {board[i].Rank} of {board[i].Suit}");
            }
            else
            {
                Console.WriteLine($"{i}. Empty");
            }
        }


    }

    public Card GetACard(int position)
    {
        if (position >= 0 && position < 9)
        {
            return board[position];
        }
        return null;
    }

    public void ReplaceCards(List<int> positions)
    {

        foreach (int pos in positions) //use the list and then iterate through that list 
        {
            if (pos >= 0 && pos < 9)
            {
                board[pos] = null;
            }

            Card replaceCard = deck.TakeTopCard();

            if (replaceCard != null) //just because you created a card doesn't mean, the deck isn't empty
            {

                replaceCard.FlipOver();
                board[pos] = replaceCard;

            }
        }

    }

    public bool IsBoardEmpty()
    {
        foreach (Card card in board)
        {
            if (card != null)
            {
                return false;
            }
        }

        return true;
    }


    


}