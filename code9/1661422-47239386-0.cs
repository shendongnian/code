    public class Program
    {
   
      public static void Main() 
      {
        string test = "";
        Change(ref test);
     }
	
	 static void Change(ref string mystring)
     {
       
        System.Console.WriteLine(mystring);
     }
    }
