    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace ConsoleApplication8
    {
        class Program
        {
            class b 
            {
                public int i;
                public b(int x) { i = x; } //Constructor which instantiates objects with respective properties
                public b() { }             //Constructor for empty object to fill gap
            }
            static void Main(string[] args)
            {
                List<b> integers = new List<b>(); //List of objects
                integers.Add(new b(5));           //Add some items
                integers.Add(new b(6));
                integers.Add(new b(7));
                integers.Add(new b(8));
                for (int i = 0; i < integers.Count; i++)
                {
                    Console.WriteLine(integers[i].i); //Do something with the items
                }
                integers.RemoveAt(1);                 //Remove the item at a specific index
                integers.Insert(1, new b());          //Fill the gap at the index of the remove with empty object
                for (int i = 0; i < integers.Count; i++)    //Do the same something with the items
                {
                    Console.WriteLine(integers[i].i);       //See that The object that fills the gap is empty
                }
                Console.ReadLine();                     //Wait for user input I.E. using a debugger for test
            }
        }
    }
