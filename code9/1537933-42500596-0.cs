    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string> {
                "Miguel", "Maddie", "John", "Isabella", "Raul" };
    
            int[] grades=new int[] { 
                90, 85, 70, 92, 87 }; // arrays, grades for each students...
    
            Console.WriteLine("Please enter your name: "); // Asking the user to type his/her name
            string studentName=Console.ReadLine();
            try{
              Console.WriteLine(studentName+" your score was "+grades[students.IndexOf(studentName)].ToString());
              }
              catch(Exception){
                Console.WriteLine("name Not found");
              }
        }
    }
