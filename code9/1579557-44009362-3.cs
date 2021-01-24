    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main()
        {
            var array = new[]{"Hello"};
            var world = array.Insert("World"); // this will crash at run time
    		
    		Console.WriteLine(array.Length);
        }
    }
    
    public static class DummyExtension
    {
        public static T Insert<T>(this IList<T> list, T insertValue)
        {
    		Console.WriteLine("WrongInsert");
            list.Add(insertValue);
            return insertValue;
        }
    	
        [Obsolete("If want a compile time exception you can do this too.", true)]
        public static T Insert<T>(this T[] list, T insertValue)
        {
    		Console.WriteLine("RightInsert");
    		return insertValue;
        }
    }
 
