    do
    {
        Console.WritLine("What is your favorit color? (Enter QUIT to stop)");
        String color = Console.ReadLine();
        String output = "";
        switch(color)
        {
            case "red":
                output = "You must be a Sith Lord";
                break;
            case "QUIT":
                output = "Good bye, thanks for playing!";
                break;
        }
        Console.WriteLine(output);
    }while(!Color.Equals("QUIT"))
