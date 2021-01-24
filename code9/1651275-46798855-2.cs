    class OtherClass{
       public int Counter {set; get;}
      .
      .//other logic
      .
    }
    OtherClass otherClass = new OtherClass();
    int count = 0; 
    while(playagain != "n")
    {
        Console.WriteLine("Please input the score of game 1: ");
        g1 = ReadLine();
        game1 += int.Parse(g1);
        count++;
        Console.WriteLine("Would you like to add more scores? Press 'n' to continue to averaging, press any other key to continue!");
        playagain = ReadLine();        
        Console.Clear();
    }
    otherClass.Counter = count;
