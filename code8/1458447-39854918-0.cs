    public class Mage : Hero
    {
        public Mage(string n) : base(n)
        {
            Name = n;
        }
    
        public override void Shout()
        {
            base.Shout();
            Console.WriteLine("Also, I am a fierce Mage!");
        }
    }
