    static void SearchDir(string dirPath)
    {
       Queue<string> queue = new Queue<string>();
       queue.Enqueue(dirPath);
       while(queue.Count() != 0) 
       {
           var actualDir = queue.Dequeue(); 
           foreach(var file in Directory.GetFiles(actualDire)
               //Output info about all files in the directory 
           foreach(var dir in Directory.GetDirectories(actualDir)
           {
               //Output info about all directories in the directory
               queue.Enqueue(dir); 
           }
       }
    } 
