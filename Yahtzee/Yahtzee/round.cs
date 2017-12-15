using System;
using System.Collections.Generic;
using System.Linq;


namespace Yahtzee
{
    class round
    {
        public int roundRolls = 1;
        public List<Die> dice = new List<Die>();
        public round()
        {
            for (int i = 0; i < 5; i++)
            {
                dice.Add(new Die());
            }

        }
      
        public void reRoll(string dieToReRollString, game game)  // rerolling the die and advancing the "rolls in current round, and rolling selected dice"
        {
            if (this.roundRolls > 2) return;
            var dieToReRollStringArray = dieToReRollString.Split(',');
            foreach (var dieNumber in dieToReRollStringArray)
            {
                int n = Convert.ToInt32(dieNumber.Trim()) - 1;
                dice[Convert.ToInt32(dieNumber.Trim()) - 1].roll();
            }
            this.roundRolls++;
           
        }
        public int getSelfCount(int num) // counts number of dice with value of "num" param
        {
            return dice.Where(x => x.value == num).ToList().Count * num;
        }
        public int threeOfKind()
        {
            if (fourOfKind() > 0) return dice.Sum(x => x.value);
            return XofAKind(3) * dice.Sum(x => x.value);

        }
        public int fourOfKind()
        {
            if (Yahtzee() > 0) return dice.Sum(x => x.value);       
            return XofAKind(4) * dice.Sum(x => x.value);

        }
        public int XofAKind(int value) // get how many groups of certain value there are
        {
            return dice.GroupBy(p => new { p.value }).Where(g => g.Count() == value).ToList().Count;
        }
        public int Yahtzee()
        {
            if (XofAKind(5) > 0) return 50 ;
            return 0;
        }
      
        public int smStraight()
        {
            if (lgStraight() > 0 || dice.GroupBy(x => new { x.value }).Distinct().ToList().Count == 4) { return 30; }
            return 0;
        }
        public int lgStraight()
        {
            var count = dice.GroupBy(x => new { x.value }).Distinct();
            if (dice.GroupBy(x => new { x.value }).Distinct().ToList().Count == 5) {
                return 40; }
            return 0;
        }
      
        public int fullHouse() 
        {
            if (threeOfKind() > 0 && XofAKind(2) > 0 ) { return 25; }
            return 0;
        }
       
        public int calcPoints(string category) // for calling auxilary functions and assigning points using the name
        {
            string c = category.Trim();
            if (c == "1s" || c == "2s" || c == "3s" || c == "4s" || c == "5s" || c == "6s") {
                return getSelfCount(int.Parse(c[0].ToString())); }
            switch (category.Trim().ToLower())
            {
                case "3 of kind":
                    return threeOfKind();
                case "4 of kind":
                    return fourOfKind();
                case "full house":
                    return fullHouse();
                case "sm straight":
                    return smStraight();
                case "lg straight":
                    return lgStraight();
                case "yahtzee":
                    return Yahtzee();
                case "chance":
                    return dice.Sum(x => x.value);
            }
            return 0;
        }

        

    }
}
