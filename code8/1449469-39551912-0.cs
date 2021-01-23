       public void Log(string whatToLog)
       {
           lock(queue) {
               string s = whatToLog + " " + DateTime.Now.ToString();
               queue.Enqueue(s);
           }    
       }
