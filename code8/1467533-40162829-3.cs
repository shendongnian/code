    using System;
    using System.Linq;
    
    class Program
    {
      static void Main()
      {
    	// Input.
    	string[] array =
    	{
    	"dot",
    	"net",
    	"perls"
    	};
    
    	// Convert each string in the string array to a character array.
    	// ... Then combine those character arrays into one.
    	var result = array.SelectMany(element => element.ToCharArray());
    
    	// Display letters.
    	foreach (char letter in result)
    	{
    	Console.WriteLine(letter);
    	}
      }
    }
    
    /* 
    Output:
    
    d
    o 
    t 
    n 
    e 
    t 
    p 
    e 
    r 
    l 
    s
    
    */
        
