     class Program {
        static void Main(string[] args) {
            var h = new Hero("Paul One-Eye");
            var m = new Mage("Zangdar the Just");
            Hero m2 = (Hero)new Mage("Copyright the Infringed");
    
            h.Shout();
            m.Shout(); 
            m2.Shout();
        }
    }
    public class Mage : Hero {
        public new void Shout() {
            base.Shout();  Console.WriteLine("Also, I am a fierce Mage!");
        }
    }
