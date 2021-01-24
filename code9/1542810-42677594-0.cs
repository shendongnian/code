    using System;
    class Program
        {
            static void numLogic()
        {
          int val;
          int oldval ;//= val;
          Random rnd = new Random();
          val = rnd.Next(1, 4)+1;
          oldval=val;
          int numberOfNumbers = 7;
          int i=0;
          while (i<numberOfNumbers)
                {
                    val = rnd.Next(1, 4) + 1;
                    if(oldval==val)continue;
                    oldval=val;
                    Console.Write("{0} ",val);
                    i++;
                }
         }
            static void Main(string[] args)
            {
                numLogic();
                
            }
        }
