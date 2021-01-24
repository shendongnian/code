    class Program
    {
      static BackgroundWorker _bw = new BackgroundWorker();
     
      static void Main()
      {
        _bw.DoWork += bw_DoWork;
        _bw.RunWorkerAsync ("Message to worker");
        Console.ReadLine();
      }
     
      static void bw_DoWork (object sender, DoWorkEventArgs e)
      {
        // This is called on the worker thread
        Console.WriteLine (e.Argument);        // writes "Message to worker"
        // Perform time-consuming task...
               //update your grid
                for (int i = 0; i < 10000; i++)
                {
                    var row = r.Next() % 10000;
                    for (int col = 1; col < 10; col++)
                    {
                        var colNum = r.Next() % 55;
                        if (table != null)
                            table.Rows[row][colNum] = "hi";r.Next().ToString();
                    }
                }
                table.AcceptChanges();
      }
    }
