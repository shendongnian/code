    using System;
    
    public static class Program {
    	public static void Main(string[] args) {
    		Console.WriteLine("The Name Game");
    		Console.Write("What's your first name? ");
    		var firstName = Console.ReadLine().Reverse();
    		Console.Write("What's your last name? ");
    		var lastName = Console.ReadLine().Reverse();
    		Console.Write("In what city were you born? ");
    		var birthPlace = Console.ReadLine().Reverse();
    		Console.Write("Result: {0} {1} {2}", firstName, lastName, birthPlace);
    	}
    
    	public static string Reverse(this string s) {
    		var arr = s.ToCharArray();
    		Array.Reverse(arr);
    		return new string (arr);
    	}
    }
