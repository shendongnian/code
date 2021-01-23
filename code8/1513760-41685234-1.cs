    class FCheck
    {
        private readonly Form1 _form;
        public FCheck(Form1 form) 
        {
            _form = form;  // <= remember Form1 instance for future use
        }
        public void tpCard_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("ThreadId:" + Thread.CurrentThread.ManagedThreadId + " " + "File:" + e.FullPath);
            if (Path.GetExtension(e.FullPath) == ".f")
            {                
                // Do something....
                _form.populateTable(tp);  // <= now it is possible to call instance methods
            }
        }
    }
