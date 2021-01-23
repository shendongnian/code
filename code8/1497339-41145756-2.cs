	double MAX_EPSILON = 1; //I assume there are constraints
	//create packman agent with initial values
    PacmanAgent agent = new PackmanAgent(0,0,0) //epsilon,alpha,gamma
    //create Process info 
	ProcessStartInfo psi = new ProcessStartInfo();
	psi.FileName = "pacman.py"
	psi.WorkingDirectory = @"C:/FilePathToPacman"
	psi.RedirectStandardOutput = true;
	string output;
	Console.WriteLine("***** Increasing Eplison Test *****");
	while( agent.Epsilon =< MAX_EPSILON )
    {
        psi.Arguments = argument;
		
        var process = Process.Start(psi); //run pacman with arguments
        output = p.StandardOutput.ReadToEnd(); //pipe output to c# variable
        process.WaitForExit(); //wait for pacman to end
		
		//Do something with test output
		Console.WriteLine("Epsilon: {0}, Alpha: {1}, Gamma: {2}",agent.Epsilon,agent.Alpha,agent.Gamma );
		Console.WriteLine("\t" + output);
		
		agent.IncrementEpsilon(0.05); //increment by desired value or default(set in IncrementEpsilon function)
    }
	
