    var background = "";
    bool breakLoop = false;
        while (!breakLoop)
        { 
            Console.WriteLine("Welcome " + name + ", " + "Please pick a class: \n" +
                              "(M)age \n" +
                              "(W)arrior \n" +
                              "(R)ogue \n");
            var readLine = Console.ReadLine();
            if (readLine != null) background = readLine.ToUpper();
            if (background == "M")
            {
                Console.WriteLine("Welcome Mage " + name);
                breakLoop = true;
            }
            else if (background == "W")
            {
                Console.WriteLine("Welcome Warrior " + name);
                breakLoop = true;
            }
            else if (background == "R")
            {
                Console.WriteLine("Welcome Rogue " + name);
                breakLoop = true;
            }
            else
                Console.WriteLine("Invalid choice"); 
        }
