using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class category // score category for game each game
    {
        public category(string name)
        {
            this.name = name;
        }
        public int points = 0;
        public string name;
        public bool used = false;

        public bool assignPoints(int points)
        {
            if (used == true) { return false; }
            this.points = points;
            this.used = true;
            return true;
        }
    }
}
