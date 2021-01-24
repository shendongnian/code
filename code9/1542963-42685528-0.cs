            Console.Clear ();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("--------------------------------------------------------------------------------");
            Console.WriteLine ("");
            Console.WriteLine ("THE RED KEEPER: {0} HP", boss.redKeeperHealth);
            Console.ResetColor ();
            Console.WriteLine ("");
    //Put your condition here so that the color will reflect:
    if (player.playerHealth > 50) {
                Console.ForegroundColor = ConsoleColor.Green;
            } else if (player.playerHealth > 20) {
                Console.ForegroundColor = ConsoleColor.Yellow;
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
            }
     Console.WriteLine ("{0}: {1} HP", player.playerName, player.playerHealth);
