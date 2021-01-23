    var name = "E. Lee";
    Console.WriteLine("Quetin: Now, your father left some unfinished work through no fault of his own.");
    Console.WriteLine("Quetin: Due to the execution of Romonav, the common people are not very happy");
    Console.WriteLine(name + ": Whose Romonav?");
    Console.WriteLine("Quetin: Lets just say that he was a bit too eager to speak his troubled mind.");
    System.Threading.Thread.Sleep(10000);
    Console.WriteLine(" ");
    Console.WriteLine("Quetin: Now, there are three options on how to deal with the rioting scum");
    while (true)
    {
        bool reply = false;
        Console.WriteLine("Quetin: You can either wipe them out, meet their demands (fair elections and for you to step down) or you can ignore them");
        Console.WriteLine("Quetin: So which one will it be, my Beloved Oppressor?");
        Console.WriteLine(" ");
        string answer = Console.ReadLine();
        //1st choice 
    
    
    
        if (answer == "wipe them out")
        {
            Console.WriteLine("Quetin: Very well my glorious leader, I will mobilise the troops");
            Console.WriteLine("-1 for people, -1 for UN and +1 for Higher Class");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Quetin: Due to the previous decision, UN has called you out for 'inhumane' killings.");
            Console.WriteLine("Quetin: However, they are yet to take action");
            Console.WriteLine("Quetin: You can either ignore them, threaten them or apologise in public");
            Console.WriteLine("Quetin: Which will it be?");
            Console.WriteLine(" ");
            string answer1 = Console.ReadLine();
            //2nd choice a
            if (answer == "apologise in public")
            {
                Console.WriteLine("Quetin: Nice choice, my Unmerciful Leader, I will organise a speech for you");
                Console.WriteLine("+1 for people, +1 for UN and -1 for Higher Class");//0 for people, 0 for UN and 0 for higher class
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine("Quetin: Exellent speech my ruler, unfortunately there seems to be a new vigilante group who does accept your apology");
                Console.WriteLine(name + ": Who are they?");
                Console.WriteLine("Quetin: They call themselves NELANZKILE, it's Zulu for 'The Clean'");
                Console.WriteLine("Quetin: Last week they assasinated a number of our officers");
                Console.WriteLine(name + ": Hmpf... Then like the Zulu, they shall be crushed");
            }
            //2nd choice a 
            if (answer == "threaten them")
            {
                Console.WriteLine("Quetin: Good idea Supreme Ruler, maybe they won't dare to take action");
                Console.WriteLine("Quetin: I will release the video of the beheading of agent Stoker to the UN");
                Console.WriteLine("/ for people, -2 for UN and +1 for higher class"); //-3 for UN, -1 for ppl and +2 for higher class
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                System.Threading.Thread.Sleep(5000);
            }
            //2nd choice a
            if (answer1 == "ignore them")
            {
                Console.WriteLine("Quetin: Very well, I will tell the officers to carry on as normal");
                Console.WriteLine("/ for people, / for UN and -1 for Higher Class"); //-1 for ppl, -1 for UN and 0 for Higher Class
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                System.Threading.Thread.Sleep(5000);
            }
    
    
        }
    
    
        if (answer == "meet their demands")
        {
            Console.WriteLine("Quetin: Good idea my Omnipotent Victor, perhaps you will be re-elected because of this");
            Console.WriteLine("+2 for people, +1 for UN and -2 for Higher Class");
            Console.WriteLine(" ");
            Console.WriteLine(name + ": Skarvich? My friend, what are you doing here with that gun?");
            Console.WriteLine("Skarvich: Forgive me Supreme Leader, but you have doomed us all with your weak will...");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("YOU HAVE BEEN ASSASINATED BY A HIGHER CLASS FRIEND DUE TO YOUR INABILITY TO STAY DICTATOR");
    
        }
        else
        {
            Console.WriteLine("Quetin: I do not think that decision will work");
            Console.WriteLine("Quetin: You can either wipe them out, meet their demands (fair elections and for you to step down) or you can ignore them");
            Console.WriteLine("Quetin: So which one will it be, my Beloved Oppressor?");
        }
        break;
    }
