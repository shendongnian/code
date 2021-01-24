    using System;
    
    class Program
    {
      public static string[] vowels = {"A", "E", "I", "O", "U"};
    
      public static void SetArrayToNull(string[] array)
      {
        array = null;
      }
    
      public static void Main(string[] args)
      {
        SetArrayToNull(ref vowels);
        Console.WriteLine(vowels == null); //now, it will writes "true" :)
      }
    }
