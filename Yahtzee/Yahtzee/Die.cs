using System;


namespace Yahtzee
{
    class Die // rolling object and stores its current value,
        //organized by its position in a list, e.g: d1 is a 0th element of a <round>
    {
        private static Random rand = new Random();
        public int value;

        public Die() // rolls on creation
        {
            this.roll();
        }

        public void roll() // roll method
        {
            this.value = rand.Next(1, 6);
        }

        
    }
}
