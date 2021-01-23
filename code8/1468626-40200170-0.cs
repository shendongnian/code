    using System;
    
    namespace ConsoleApplication
    {
    	class BMIBlueprint
    	{
    		private const int BMI_VAR = 703;
    
    		public double Bmi { get; private set; }
    
    		public BMIBlueprint(double height, double weight)
    		{
    			Bmi = height * height * weight;
    		}
    
    		public void Adjust()
    		{
    			Bmi *= BMI_VAR;
    		}
    	}
    
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.Write("Enter weight: ");
    			double weight = double.Parse(Console.ReadLine());
    
    			Console.Write("Enter height: ");
    			double height = double.Parse(Console.ReadLine());
    
    			BMIBlueprint calcBmi = new BMIBlueprint(height, weight);
    
    			calcBmi.Adjust();
    
    			//then display after calculated
    			Console.WriteLine("The finished cal should be shown here: {0:N2}", calcBmi.Bmi);
    
    			Console.Write("\nPress any key...");
    			Console.ReadKey();
    		}
    	}
    }
