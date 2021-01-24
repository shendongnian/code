            static void Main(string[] args)
            {
                Create.Characters();
                Dragon BlackDrag = Create.BlackDrag;
            }
        }
        public class Create
        {
            public static Hero Dash { get; set; }
            public static Bandit Keith { get; set; }
            public static Bandit Leader { get; set; }
            public static Knight Leeroy { get; set; }
            public static Knight Seth { get; set; }
            public static Dragon BlueDrag { get; set; }
            public static Dragon RedDrag { get; set; }
            public static Dragon BlackDrag { get; set; }
     
            public static void Characters()
            {
                Dash = new Hero("Dash", 3, 10);
                Keith = new Bandit("Keith", 1, 5);
                Leader = new Bandit("Bandit Leader", 2, 8);
                Leeroy = new Knight("Leeroy", 3, 12);
                Seth = new Knight("Seth", 5, 15);
                BlueDrag = new Dragon("Blue Dragon", 7, 20, 2);
                RedDrag = new Dragon("Red Dragon", 8, 20, 3);
                BlackDrag = new Dragon("BlackDrag", 10, 25, 4);
            }
        }
