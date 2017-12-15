using System;
using System.Linq;


namespace Yahtzee
{
    class Program
    {
        static void Score(game game, string input) // to score points for the round
        {
            UI.showUI(game);
            if (input == null) { input = UI.prompt("Select a category to score in: "); }
            var submitted = (from ctg in game.Score where ctg.name == input.Trim().ToLower() select ctg).ToList();
            while (submitted.Count == 0|| submitted.First().used)
            {
                if (submitted.Count != 0) Console.Write("Category Already Used... please choose another: ");
                if (submitted.Count == 0) Console.Write("Invalid input, choose a valid category: ");
                input = Console.ReadLine();
                submitted = (from ctg in game.Score where ctg.name == input.Trim().ToLower() select ctg).ToList();
            }
            submitted.First().assignPoints(game.currentRound.calcPoints(input.Trim().ToLower()));
            UI.showCard(game);
            UI.prompt("Press any key To continue...");
            game.newRound();
        }
        static void Main(string[] args) // entry....
        {
            game game = new game();
            bool erroneousInput = false;

            Console.WriteLine("Welcome to Yahtzee!");

            while (game.gameOver == false)//move this into ui loop...make const for red writing...
            {
                if (game.currentRound.roundRolls > 2) { Score(game, null);  }
                if (erroneousInput == false) UI.showUI(game);
                erroneousInput = false;
                string input = UI.prompt("Select a category, pick the dice to re-roll (Ex. 1,2,3) or \"show\" for score-cardChoice(< category >/#,#,#/show):");
                var submitted = (from ctg in game.Score where ctg.name == input.Trim().ToLower() select ctg).ToList();


                if (input.ToLower().Trim() == "show") // selected show
                {
                    UI.showCard(game);
                    Console.WriteLine("Press any key to Continue...");
                    Console.ReadKey();
                }

                else if (submitted.Count > 0) // to score 
                {               
                    Score(game, input);
                }

                else {
                    try
                    {
                        game.currentRound.reRoll(input, game);
                    }

                    catch { Console.WriteLine("Error, Invalid Input..."); erroneousInput = true; }
                    
                    }
            }


            Console.WriteLine("Game Over! Here Are your results: ");
            UI.showCard(game);
            Console.WriteLine("Press any Key to Exit...");
            Console.ReadKey();
        }
    }
}
