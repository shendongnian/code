    Random generator = new Random();
    bool truth = true;
    
    //extra semicolon on next line, 
    //doesn't make sense to convert a boolean to get your initial max range,
    //just give it an initial value, perhaps 0
    int MaxRange = Convert.ToInt32(truth); ;
    int userguess = 0;
    
    //the generator can't get the correct outputnumber yet because MaxRange hasn't
   	//been set by the user's input yet
    int outputnumber = generator.Next(MaxRange);
    do
    {
    	//this won't get the user input because the parameters in WriteLine() 
    	//that come after the string are for inserting into the string, not recieving input
        Console.WriteLine(" Enter a max number you want to guess from!", MaxRange);
        
        //need to set Console.ReadLine() to a variable for it to be saved
        //should be MaxRange = Console.ReadLine(); (though that will throw an error if the user inputs anything except numbers)
        Console.ReadLine();
        //outputnumber hasn't been set to a true generated number yet
        Console.WriteLine("please make a guess between 1 and {0}", outputnumber);
        //outputnumber could be renamed to be more clear, I would suggest randomNumber
        //userguess is still 0 during the first loop, need to get the user's guess before comparing to the random number
        //also, could simplify these if/else statements to just a couple of them
        //you're also going to need a while loop somewhere in here to continue having the user
        //guess until they get it right
        if (userguess != outputnumber)
        {
            //should use Console.ReadLine()
            userguess = Convert.ToInt32(Console.Read());
            if (userguess < outputnumber)
            {
                Console.WriteLine("That is not correct, Guess again");
                Console.ReadLine();
            }
            if(userguess > outputnumber)
            {
                Console.WriteLine("That is not correct, Guess again");
                Console.ReadLine();
            }
            else if (userguess == outputnumber)
            {
    //not indented correctly, missing correct capitalization and missing the right quotes on the string to be wrote
    console.writeline("That is correct, the number is {0}, outputnumber);
            }
        }
    //should just be while (true);
    } while (truth == false);
    }
	}
}
