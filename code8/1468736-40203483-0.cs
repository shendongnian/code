    public class Dog
            {
                private string barkSound;
                private string breed;
                private int dogHeight;
                private string dogColour;
                public Dog(string bark, string breed, int height, string color)
                {
                    this.barkSound = bark;
                    this.breed = breed;
                    this.dogHeight = height;
                    this.dogColour = color;
    
                }
                public string BarkingSound { get { return this.barkSound; } }
                public string BreedName { get { return this.breed; } }
                public string Height { get { return this.dogHeight.ToString(); } }
            }
