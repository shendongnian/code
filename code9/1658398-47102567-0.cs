    void Main()
    {
    	string response;
    
                string[] workerName = new string[2]; //100
                for (int i = 0; i < workerName.Length; i++)
            {
    			
                Console.WriteLine("Do You Want To Enter A Worker's Name? Y or N: ");
                response = Console.ReadLine().Substring(0,1).ToLower();
                if (response == "y"){
                    Console.WriteLine("Please Enter The Worker's Name: ");
    				workerName[i] = Console.ReadLine();
    				}
                else continue;
            }
    		Console.WriteLine("Worker Names entered are: ");
    		for(int i = 0; i< workerName.Length; i++) {
    			Console.WriteLine(workerName[i]);
    		}
    }
    
