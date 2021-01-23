    using System;
    					
    public class Program
    {
        public static void Main(string[] args)
        {
            int x=0;
            int y=0;
    		char[,] coordinates = new char[20,20];
    		
            while (true)
            {
    			//user must enter 2 3 for example.
    			string[] response = Console.ReadLine().Split(new[]{" "}, StringSplitOptions.RemoveEmptyEntries);
    			if (response[0].ToLower() == "stop")
    				break;
    
    			x = int.Parse(response[0]);
    			y = int.Parse(response[1]);
    								
    			coordinates[x,y] = '*';
    		}
    		
           
    		//Print the output
    		for(var i = 0; i < 20; i++)
    		{
    			for( var j = 0; j < 20; j++)
    				if (coordinates[i,j] == (char)0)
    					Console.Write('#');
    				else 
    					Console.Write(coordinates[i,j]);
    				
    			Console.WriteLine();
    		}
        }
    }
