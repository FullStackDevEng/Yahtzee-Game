using System;
using System.Collections.Generic;
using System.Linq;

namespace Yahtzee
{

    class UI // user interface generator (via print strings to console)
    {
        private static string getRollDisplay(List<Die> dice) // return string containing the current roll...
        {
            string output = string.Empty;

            for (int i = 0; i < dice.Count; i++)
            {
                output += "D" + (i + 1).ToString() + ": " + dice[i].value + "  ";
            }
            return output;
        }
        public static void showCard(game game) // shows the score card
        {
            string output = string.Empty;
            output += "-------";
            output += "|    Score Card     |";
            output += "-------";
            output += Environment.NewLine+  "Category" + replicate(" ", 20 - "Category".Length) + "Points" + Environment.NewLine;

            foreach (var ctg in game.Score)
            {
                output += ctg.name + replicate(" ", 20 - ctg.name.Length) + ctg.points + Environment.NewLine;

            }
            output += "-------------" + Environment.NewLine;
            output += "Total" + replicate(" ", 20 - "Total".Length) + game.Score.Sum(x => x.points) + Environment.NewLine;
            Console.WriteLine(output);
        }
       
        public static void showUI(game game)// shows main interface
        {
            string output = string.Empty;
            output += "--- Round " + game.rounds.Count.ToString() + " ---" + Environment.NewLine;
            output += "Rolling Dice...(" + "rolls for round: "+ game.currentRound.roundRolls + ")" + Environment.NewLine;
            output += "You rolled the following: " + Environment.NewLine;
            output += getRollDisplay(game.currentRound.dice) + Environment.NewLine;
            output += "Category" + replicate(" ", 20 - "Category".Length) + "Points" + Environment.NewLine;
            //output = attachScore(output, game, false);
            foreach (var ctg in game.Score)
            {
                output += ctg.name + replicate(" ", 20 - ctg.name.Length) + game.currentRound.calcPoints(ctg.name) + Environment.NewLine;
            }

            Console.WriteLine(output);
        }
        public static string prompt(string prompText)
        {

            Console.Write(prompText);
            return Console.ReadLine();
        }
        private static string replicate(string str, int n)
        {
            string prod = string.Empty;
            for(int i = 0; i < n; i++)
            {
                prod += str;
            }
            return prod;
        }
       
    }
}
