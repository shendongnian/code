    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		double[] questionOne = {1, 4, 5, 2, 4};
    		double[] questionTwo = {3, 2, 4, 5, 2};
    		var combined = questionOne.Zip(questionTwo, (q1, q2) => (q1, q2)).ToList();
    		Console.WriteLine(combined);
    	}
    }
