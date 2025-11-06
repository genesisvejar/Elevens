using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDeck
{
    public class Card
    {
        //Fields, example: Rank rank;
        //check the help documentation for the fields
        private Rank rank;
        private Suit suit;
        private bool faceUp;


        //Card Constructor

        public Card(Rank r, Suit s) 
        {
            rank = r;
            suit = s;
            faceUp = false;
        }


        //Define properties for all above fields
        //code example: public Suit Suit { get { return suit; } }

        public Suit Suit
        {
            get { return suit; }

        }
        public Rank Rank
        {
            get { return rank; }

        }

        public bool FaceUp
        {
            get { return faceUp; }
        }


        public void FlipOver()
        {
            faceUp = !faceUp;
        }


    }
}
