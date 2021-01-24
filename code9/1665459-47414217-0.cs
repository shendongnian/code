    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        public static void Main()
        {
            List<object> mainList = new List<object>();
    
            mainList.Add(1); 
            mainList.Add(2); 
    
            List<object> avlDataList = new List<object>();
    
            for (int i = 0; i < 10; i++)           
                avlDataList.Add(100 + i);  
    
            mainList.Add(avlDataList); 
    
            foreach (var i in mainList)
            {
                if (i.GetType() != avlDataList.GetType())
                    Console.WriteLine(i);  
    
                if (i.GetType() == avlDataList.GetType())                
                    foreach (var ii in avlDataList)
                        Console.WriteLine(ii); 
            }
        }
    }
