    internal static class P
    {
        private static void Main ()
        {
            int hp = 100;
            int gold = 10;
            Console.WriteLine("Before:");
            Console.WriteLine($"\tHP: {hp}\n\tGold: {gold}\n");
            
            location1 loc1 = new location1();
            
            loc1.useYourSword(ref hp, ref gold, "", "");
            Console.WriteLine("After:");
            Console.WriteLine ($"\tHP: {hp}\n\tGold: {gold}");
            Console.ReadLine ();
        }
    }
    class location1
    {
        public void useYourSword (ref int hp, ref int gold, string name, string age)
        {
            Random rnd = new Random ();
            int monster = 10;
            gold = gold - 1;
            while (monster > 0 && hp > 0)
            {
                int dmgdone = rnd.Next (1, 10);
                Console.WriteLine ("You deal " + dmgdone);
                monster = monster - dmgdone;
                int dmg = rnd.Next (1, 10);
                Console.WriteLine ("You take " + dmg);
                hp = hp - dmg;
                if (monster <= 0)
                {
                    Console.WriteLine ("Monster is slain");
                    gold = gold + 1;
                }
                if (hp <= 0)
                {
                    Console.WriteLine ("You where killed");
                }
            }
            Console.ResetColor ();
        }
    }
