    public static void Main(string[] args)
    {
       while (true)
       {
          // datas setting
          initDatas();
          // Random treasure position selection
          setupWinningPosition();
        
          // This is cheating: some kind of debugging so you can test the results
          Console.WriteLine("Don' t tell tx=" + winningX + " and tY = " + winningY);
        
          Console.WriteLine("Enter x");
          int x = Int32.Parse(Console.ReadLine());
          Console.WriteLine("Enter y");
          int y = Int32.Parse(Console.ReadLine());
        
          if (hasGotTheTreasure(x, y))
          {
             Console.WriteLine("You got the treasure dude!!!");
          }
    
          // A radius of 1 is used here
          else if (isInTheViccinityOfTreasure(1, x, y))
          {
             Console.WriteLine("That's getting hot: keep going boy...");
          }
          else
          {
             Console.WriteLine("Oops it's getting very cold");
          }
        
          // This is the way out of the loop by hitting 'q'
          ConsoleKeyInfo key = Console.ReadKey();
          if (key.KeyChar == 'q')
          {
             break;
          }   
       }
    }
