     bool secondCorectAnswer = true;
     while (secondCorectAnswer)
     {
        //do your stuff
        
         Console.WriteLine("Mr.Smith has 4 daughters. Each of his daugthers has a brother. How many children does Mr.Smith has?");
            
         if(Console.ReadLine() == "5 children")
         {
              Console.WriteLine("That is correct. you gained 5 points!");
              points = easyPoints + 5;
              Console.WriteLine("You have a total of  " + easyPoints + " points");
              secondCorectAnswer=false;
         }
         else
         {
              Console.WriteLine("Sorry that is not correct!");
         }
     }
