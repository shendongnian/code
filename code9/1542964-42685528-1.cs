            Console.Clear ();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("--------------------------------------------------------------------------------");
            Console.WriteLine ("");
            Console.WriteLine ("THE RED KEEPER: {0} HP", boss.redKeeperHealth);
            Console.ResetColor ();
            Console.WriteLine ("");
            Console.Write("{0}: ", player.playerName);
    //Put your condition here so that the color will reflect:
    if (player.playerHealth > 50) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else if (player.playerHealth > 20) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }
     Console.Write ("{0} HP", player.playerHealth);
