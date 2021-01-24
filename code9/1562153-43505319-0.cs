    private Object lockObj = new Object();  
       
     public void FileOperation(decimal amount)  
     {  
        //Subsequent thread calls will queue up 
        lock (lockObj)  
        {          
          using (System.IO.StreamWriter file = 
                    new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
                {
                    //Long running operation  
                    for(var i = 1; i < 1000000; i++)
                    {
                       file.WriteLine("Fourth line");
                    }
                } 
        }
    }
