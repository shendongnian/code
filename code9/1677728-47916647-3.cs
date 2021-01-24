    TaskScheduler _Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    //No async here
    public void OnDrop(object sender, DragEventArgs e)
    {
       string _dropped = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
       if (_dropped.Contains(".csv") || _dropped.Contains(".txt"))
       {
          Task.Factory.StartNew(() =>
          {
             string _s = string.Empty;
             int x = 0;
             try
             {
                using (TextReader tr = new StreamReader(_dropped))
                {
                   while (tr.Peek() >= 0)
                   {
                      _s += (tr.ReadLine().Replace(";", " ")) + "\r\n";
                      ++x;
                      //Update the UI after reading 20 lines
                      if (x >= 20)
                      {
                         //Update the UI or report progress 
                         Task UpdateUI = Task.Factory.StartNew(() =>
                         {
                            try {
                               values.AppendText(_s);
                            }
                            catch (Exception) {
                               //An exception is raised if the form is closed
                            }
                         }, CancellationToken.None, TaskCreationOptions.PreferFairness, _Scheduler);
                         UpdateUI.Wait();
                         x = 0;
                      }
                   }
                }
             }
             catch (Exception) {
                //Do something here
             }
          });
       }
    }
