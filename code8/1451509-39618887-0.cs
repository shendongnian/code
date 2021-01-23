    public class Egg
    {
        public void BounceRock(Rock rock)
        {
            // Bounce the rock...
        }
    
        public void BounceRocks(List<Rock> rocks)
        {
            foreach(Rock rock in rocks)
            {
                BounceRock(rock);
            }
        }
    }
