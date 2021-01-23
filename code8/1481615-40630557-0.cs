    //create an enumerable containing the numbers 0,1,2,3 and randomize it
    Random r = new Random();
    int[] options = Enumerable.Range(0, 4).OrderBy(o => r.Next()).ToArray(); 
    //prints options
    foreach (int option in options)
    {
         if (mcq.optionsBool[x, option] == true)  //replaced 'y' with 'option'
         {
              int z = gen.Next(4);
              Console.WriteLine("[" + optionCount + "]" + mcq.options[x, z]);
              mcq.optionsBool[x, z] = true;
         }
         else (mcq.optionsBool[x, option] == false) //there are only two possible options so use Else instead of ElseIf
         {
             Console.WriteLine("[" + optionCount + "]" + mcq.options[x, option]);
             mcq.optionsBool[x, option] = true;  
         }
         Wait(1);         //These two lines were present on
         optionCount++;   //both if and else, so I placed them outside
    }
