    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string calculation = "2+3+81%";
            int length = calculation.Length;
            if(!Char.IsNumber(calculation[length-1])){
                calculation = calculation.TrimEnd(calculation[length-1]);
            }
            Console.Write(calculation);
    	}
    }
