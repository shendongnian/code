    public class Player
    {
        private int gold = 0;
        private int goldLeftInChests = 85000000;
        private int chestsToOpen = 10000;
        private Random random = new Random();
        public void OpenChest()
        {
            if (chestsToOpen == 0)
                return; // or whatever you want after 10000 chests.
            int goldInChest = CalculateGoldInNextChest();
            goldLeftInChests -= goldInChest;
            chestsToOpen--;
            gold += goldInChest;
        }
        private int CalculateGoldInNextChest()
        {
            if (chestsToOpen == 1)
                return goldLeftInChests;
            var average = goldLeftInChests / chestsToOpen;
            return random.Next(average);
        }
    }
