
using System.Collections.Generic;


namespace Yahtzee
{
    class game
    {
        public category[] Score = { // score categories for the game instance

            new category("1s"),
            new category("2s"),
            new category("3s"),
            new category("4s"),
            new category("5s"),
            new category("6s"),
            new category("3 of kind"),
            new category("4 of kind"),
            new category("full house"),
            new category("sm straight"),
            new category("lg straight"),
            new category("yahtzee"),
            new category("chance")
        };
        public round currentRound; // current round reference
        public List<round> rounds = new List<round>();
        public bool gameOver = false;
        public int totalScore = 0;
        public game() // initiates a round when starting up...
        {
            this.currentRound = new round();
            rounds.Add(currentRound);

        }

        public void newRound() // initiates a new round 
        {
            if (rounds.Count < 13) { currentRound = new round() ; rounds.Add(currentRound); }
            else { gameOver = true; }

        }
        
        
    }
}
