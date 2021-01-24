    using System;
    public class Test{
    	private static String[] values = {"A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","A","B","B","B","B","B","B","B","B","B","B","B","B","B","B","B","C","C","C","C","C","C","C","D","D","D","D",};
    	
    	private static Random PRNG = new Random();
    	
		public static void Main(){
			Console.WriteLine( values[PRNG.Next(values.Length)] );
    	}
    }
