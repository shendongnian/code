    while (!acceptInput)
    {
        playerChoice = GetUserInput(); // GetUserInput() return user input string
        if (playerChoice.Equals("a"))
        {
            player.PlayerAttack();
            if (Random.NextDouble() > 0.9)
            {
                Console.WriteLine("You Missed!");
                Console.WriteLine("Press 'Enter' to Continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("It's a hit!");
                monster.MonsterDecreaseHealth(player.AttackPower);
                Console.WriteLine("Press 'Enter' to Continue...");
                Console.ReadLine();
            }
            acceptInput = true;
        }
        else if (playerInput.Equals("h"))
        {
            player.PlayerHeal();
            acceptInput = true;
        }
        else
        {
            Console.WriteLine("That is not a valid choice, please enter either A or H");
        }
    }
