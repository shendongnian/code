    foreach(var pr in d)
    {
       List<InputData[]> a = pr.Value;
       StringBuilder sb = new StringBuilder();
    
    sb 
       foreach(var b in a)
       {
          foreach (var c in b)
          {
             if (c != null)
                Console.WriteLine(c.dataThing);
          }                        
       }
       Console.WriteLine(pr.Key);  //--I want to display c.dataThing on the same line as pr.Key
    }  
