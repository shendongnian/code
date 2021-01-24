      public static void Main(string[] args)
      {
    	Console.WriteLine("enter your first number: ");
    	string NumOne = Console.ReadLine(); // store users input
    
    	Console.WriteLine("enter your second number: ");
    	string NumTwo = Console.ReadLine(); // store users input
    
    	Console.WriteLine("enter operator e.g / , + , - , * ");
    	string Operator = Console.ReadLine(); // store users input
    
    	double CurrentNumber;
    	if (double.TryParse(NumOne, out CurrentNumber) && double.TryParse(NumTwo, out CurrentNumber)) //validation
    	{
    		if (Operator.Length == 1) // validation
    		{
    			Calculator(double.Parse(NumOne), double.Parse(NumTwo), Operator[0]); 
    		}
    	}
    	Console.ReadKey();
     }
    
    
    
    public static double Multiplication(double NumOne, double NumTwo) => NumOne * NumTwo; // multiplication
    public static double Division(double NumOne, double NumTwo) => NumOne / NumTwo; // division
    public static double Addition(double NumOne, double NumTwo) => NumOne + NumTwo;  //addition
    public static double Subtraction(double NumOne, double NumTwo) => NumOne - NumTwo; // subtraction
    
    public static void Calculator(double NumOne, double NumTwo, char Operator)
    {
    	switch (Operator)  
    	{
    		case '*': Console.WriteLine($"Muliplication Result: {Multiplication(NumOne, NumTwo)}");
    			break;
    
    		case '/':
    			Console.WriteLine($"Division Result: {Division(NumOne, NumTwo)}");
    		   break;
    
    		case '+':
    			Console.WriteLine($" Addition Result: {Addition(NumOne, NumTwo)}");
    			break;
    
    		case '-':
    			Console.WriteLine($" Subtraction Result: {Subtraction(NumOne, NumTwo)}");
    			break;
    					
    		default: Console.WriteLine("Wrong operator entered");
    			break;
    	}
    }
