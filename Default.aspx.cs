using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWarGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void okButton_Click(object sender, EventArgs e)
        {
            //Create Players
            Player player1 = new Player();
                player1.Name = "Steve";
                player1.Hand = new List<Deck>();
            Player player2 = new Player();
                player2.Name = "George";
                player2.Hand = new List<Deck>();

            //Create CardDeck
            Deck deck = new Deck();
            List<Deck> cardDeck = new List<Deck>();
            cardDeck = deck.CreateDeck();
            
            //Deal Cards
            Random random = new Random();

            while (cardDeck.Count()>0)
            {
                int index = random.Next(cardDeck.Count());
                player1.Hand.Add(new Deck { Value = cardDeck[index].Value, Suit = cardDeck[index].Suit });
                resultLabel.Text += String.Format("Player 1: {0}", cardDeck[index].Suit);
                cardDeck.RemoveAt(index);

                index = random.Next(cardDeck.Count());
                player2.Hand.Add(new Deck { Value = cardDeck[index].Value, Suit = cardDeck[index].Suit });
                resultLabel.Text += String.Format("&nbsp;&nbsp;Player 2: {0}<br>", cardDeck[index].Suit);
                cardDeck.RemoveAt(index);
            };

            //Battle

            
            
                for (int i = 0; i < 21 && i<player1.Hand.Count() && i<player2.Hand.Count(); i++)
                {
                    
                    if (player1.Hand[i].Value > player2.Hand[i].Value)
                    {
                        resultLabel.Text += String.Format("Bounty goes to {0}: {1} & {2}<br>", player1.Name, player1.Hand[i].Suit, player2.Hand[i].Suit);
                        player1.Hand.Add(new Deck { Value = player2.Hand[i].Value, Suit = player2.Hand[i].Suit });
                        player2.Hand.RemoveAt(i);
                    }
                    else if (player2.Hand[i].Value > player1.Hand[i].Value)
                    {
                        resultLabel.Text += String.Format("Bounty goes to {0}: {1} & {2}<br>", player2.Name, player1.Hand[i].Suit, player2.Hand[i].Suit);
                        player2.Hand.Add(new Deck { Value = player1.Hand[i].Value, Suit = player1.Hand[i].Suit });
                        player1.Hand.RemoveAt(i);
                    }
                    else if (player1.Hand[i].Value == player2.Hand[i].Value)
                    {
                        resultLabel.Text += String.Format("******** War ********<br>");
                        if (player1.Hand[i + 4].Value > player2.Hand[i + 4].Value)
                        {
                            resultLabel.Text += String.Format("Bounty goes to {0}: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, & {10}<br>",
                                player1.Name, player1.Hand[i].Suit, player2.Hand[i].Suit, player1.Hand[i + 1].Suit, player2.Hand[i + 1].Suit,
                                player1.Hand[i + 2].Suit, player2.Hand[i + 2].Suit, player1.Hand[i + 3].Suit, player2.Hand[i + 3].Suit,
                                player1.Hand[i + 4].Suit, player2.Hand[i + 4].Suit);
                            player1.Hand.Add(new Deck { Value = player2.Hand[i].Value, Suit = player2.Hand[i].Suit });
                            player1.Hand.Add(new Deck { Value = player2.Hand[i + 1].Value, Suit = player2.Hand[i + 1].Suit });
                            player1.Hand.Add(new Deck { Value = player2.Hand[i + 2].Value, Suit = player2.Hand[i + 2].Suit });
                            player1.Hand.Add(new Deck { Value = player2.Hand[i + 3].Value, Suit = player2.Hand[i + 3].Suit });
                            player1.Hand.Add(new Deck { Value = player2.Hand[i + 4].Value, Suit = player2.Hand[i + 4].Suit });

                            player2.Hand.RemoveRange(i, 5);
                        }
                        else if (player2.Hand[i + 4].Value > player1.Hand[i + 4].Value)
                        {
                            resultLabel.Text += String.Format("Bounty goes to {0}: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, & {10}<br>",
                                player2.Name, player1.Hand[i].Suit, player2.Hand[i].Suit, player1.Hand[i + 1].Suit, player2.Hand[i + 1].Suit,
                                player1.Hand[i + 2].Suit, player2.Hand[i + 2].Suit, player1.Hand[i + 3].Suit, player2.Hand[i + 3].Suit,
                                player1.Hand[i + 4].Suit, player2.Hand[i + 4].Suit);
                            player2.Hand.Add(new Deck { Value = player1.Hand[i].Value, Suit = player1.Hand[i].Suit });
                            player2.Hand.Add(new Deck { Value = player1.Hand[i + 1].Value, Suit = player1.Hand[i + 1].Suit });
                            player2.Hand.Add(new Deck { Value = player1.Hand[i + 2].Value, Suit = player1.Hand[i + 2].Suit });
                            player2.Hand.Add(new Deck { Value = player1.Hand[i + 3].Value, Suit = player1.Hand[i + 3].Suit });
                            player2.Hand.Add(new Deck { Value = player1.Hand[i + 4].Value, Suit = player1.Hand[i + 4].Suit });

                            player1.Hand.RemoveRange(i, 5);
                        }
                    }
              
                };
                
           
                //Winner
                if (player1.Hand.Count() > player2.Hand.Count())
                {
                    resultLabel.Text += String.Format("<br>{0}'s Score: {1}  {2}'s Score: {3}<br>Winner is: {0}",
                        player1.Name, player1.Hand.Count(), player2.Name, player2.Hand.Count());
                }
                else
                {
                    resultLabel.Text += String.Format("<br>{0}'s Score: {1}  {2}'s Score: {3}<br>Winner is: {2}",
                        player1.Name, player1.Hand.Count(), player2.Name, player2.Hand.Count());
                }







            
        }
    }
}