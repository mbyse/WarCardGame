using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWarGame
{
    public class Deck
    {
        public string Suit { get; set; }
        public int Value { get; set; }
        public string Card { get; set; }
        public int Draw { get; set; }
        public List<Deck> Hand { get; set;}
          

        public List<Deck> CreateDeck()
        {
            List<Deck> deck = new List<Deck>();
            for (int i = 2; i < 15; i++)
            {
                string num = i.ToString();

                if (i == 11) num = "Jack";
                else if (i == 12) num = "Queen";
                else if (i == 13) num = "King";
                else if (i == 14) num = "Ace";

                deck.Add(new Deck{ Value = i, Suit = num+" of Hearts" });
                deck.Add(new Deck { Value = i, Suit = num+" of Spades" });
                deck.Add(new Deck { Value = i, Suit = num+" of Diamonds" });
                deck.Add(new Deck { Value = i, Suit = num+" of Clubs" });
            };
           return deck;


            /* foreach (var Deck in deck)
             {
                 resultLabel.Text += String.Format("{0} of {1} <br>", Deck.Value, Deck.Suit);
             }*/
        }


    }
    
}