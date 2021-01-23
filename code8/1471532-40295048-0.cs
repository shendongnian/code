    using System;
    using System.Threading;
    
    class Program
    {
        static readonly object _fileAccess = new object();
    
        static void Write()
        {
            // Obtain lock and write
            lock (_fileAccess)
            {
                // Write data to filename
                xmlDoc.Save(filename);
            }
        }
        
        static void Read()
        {
            // Obtain lock and read
            lock (_fileAccess)
            {
                // Read some data from filename
                xmlDoc.load(filename);
            }
        }
    
        static void Main()
        {    	
    	    ThreadStart writeT = new ThreadStart(Write);
    	    new Thread(writeT).Start();
            
            ThreadStart readT = new ThreadStart(Read);
    	    new Thread(readT).Start();
        }
    }
