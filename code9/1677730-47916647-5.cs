    TaskScheduler _Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
    //No async here
    public void OnDrop(object sender, DragEventArgs e)
    {
       string dropped = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
       if (dropped.Contains(".csv") || dropped.Contains(".txt")) {
          Task.Factory.StartNew(() => {
             string line = string.Empty;
             int x = 0;
             try {
                using (var reader = new StreamReader(dropped)) {
                   while (reader.Peek() >= 0) {
                      line += (reader.ReadLine().Replace(";", " ")) + "\r\n";
                      ++x;
                      //Update the UI after reading 20 lines
                      if (x >= 20) {
                         //Update the UI or report progress 
                         Task UpdateUI = Task.Factory.StartNew(() => {
                            try {
                               values.AppendText(line);
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
