        void BackgroundWorker1DoWork(object sender, DoWorkEventArgs e)
		{  
              string[] extensions = { ".htm", ".html" };
              var files = Directory.EnumerateFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories)
           	 .Where(s => s.EndsWith(".html") || s.EndsWith(".htm")).OrderBy(f => f);
			
			     	
              foreach (string file in files)
               {  
              	Thread.Sleep(5);
              	System.Diagnostics.Debug.WriteLine(file);
                  backgroundWorker1.ReportProgress(0,file+Environment.NewLine);
               }
			
			
		}
		void BackgroundWorker1ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
	
          textBox2.AppendText(e.UserState as string);
		}
