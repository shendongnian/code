    public class Dog
    {
        public Dog()
        {
            barkSound = "Woof!";
            breed = "cocker spaniel";
            dogHeight = 10;
            dogColour = "white";
            noOfLEgs = 4;
        }
        public string barkSound { get; private set; }
        public string breed { get; private set; }
        public string dogColour { get; private set; }
        public int dogHeight { get; private set; }
        public int noOfLEgs { get; private set; }
        public string GetSpeech()
        {
            string dogSpeech = "Hello. I am a " + breed + ". " + barkSound + " I'm "
                        + (IsBig(dogHeight) ? "Big" : "Small") + ", Colour is " + dogColour + ", I have " + noOfLEgs + " legs";
            return dogSpeech;
        }
        private bool IsBig(int dogHeight)
        {
            if (dogHeight < 50)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
