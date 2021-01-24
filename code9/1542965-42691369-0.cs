           public static void redKeeperBattle()
    {
            Console.Clear ();
            Console.ForegroundColor = ConsoleColor.Red;
           // Write your condition here like this.
           //The last else condition is not needed as the default colour is mention as red by above line
            if (player.playerHealth > 50) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else if (player.playerHealth > 20) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } 
            Console.WriteLine ("--------------------------------------------------------------------------------");
            Console.WriteLine ("");
            Console.WriteLine ("THE RED KEEPER: {0} HP", boss.redKeeperHealth);
            Console.ResetColor ();
            Console.WriteLine ("");
            Console.WriteLine ("{0}: {1} HP", player.playerName, player.playerHealth);
            Console.WriteLine ("");
            Console.WriteLine ("");
            Console.WriteLine ("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine ("What would you like to do?");
            Console.WriteLine ("1) Attack");
            Console.WriteLine ("2) Dodge");
            Console.ResetColor ();
            Console.ReadLine();
}
