    using System;
    using System.Collections.Generic;
    public class Program
        {
            public static void Main(string[] args)
            {
                Program p = new Program();
                student s = new student();
    
                foreach (var item in p.ab())
                {
                    Console.WriteLine(item.id+item.name+item.fname);  
                }
    
            }
    
            public  List<student> ab() 
            {
                List<student> l = new List<student>()
                  {
                     new student{id=1,name="hjk",fname="xyz"},
                  };
                return l;
             }
    
    }
     public class student
            {
                public int id { get; set; }
                public String name { get; set; }
                public String fname { get; set; }
            }
