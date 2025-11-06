using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CardDeck;

namespace CardDeck{

    public class Deck
    {
        private List<Card> cards = new List<Card>();

        //Deck Constructor
        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    //create a new card and add it to the deck

                    Card aDeckCard = new Card(rank, suit);
                    cards.Add(aDeckCard);

                }
            }
        }

        //Implement a property to get Cards
        public List<Card> Cards
        {
            get { return cards; }

        }

        //Takes top card from deck (if deck is not empty, otherwise return null)
        public Card TakeTopCard()
        {
        
            if (cards.Count == 0)
            {
                return null;
            
            }

            Card topCard = cards[0];

            cards.RemoveAt(0);

            return topCard;
    }

        //Shuffle Method
        public void Shuffle()
        {
            Random random = new Random();

            for (int i = 0; i < cards.Count; i++)
            {
                int randomNum = random.Next(cards.Count);
               
                Card temp;
                temp = cards[i];

                cards[i] = cards[randomNum];
                cards[randomNum]= temp;



            }
        
        }

        //Cut method
        public void Cut(int index)
        {
            List<Card> cutDeck = new List<Card>();

            for (int i = index; i < cards.Count; i++)
            {

                cutDeck.Add(cards[i]);

            }

            for (int i = 0; i < index; i++)
            {

                cutDeck.Add(cards[i]);

            }
            cards = cutDeck;


        }

}
}
    
        
        
    


/*
  
  
}
*/