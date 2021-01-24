    if (age >= 12)
    {
      Console.WriteLine("You may enter");
    }
    else
    {
      string response = null;
      while(response != "yes" || response != "no"){
    	response = Console.WriteLine("Are you accompanied by an adult? Answer yes or no" );
      }
      
      Console.ReadLine();
      if (response == "yes")
      {
    	Console.WriteLine("You may pass.");
      }
      //Only other way to get here is if they answered, "no" so don't need to check response
      else{
    	Console.WriteLine("You are not allowed.");
      }
    }
