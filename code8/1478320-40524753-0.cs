            string[] images = new string[50];
            foreach (var path in images)
            {
                BackgroundWorker w = new BackgroundWorker();
                //50 independently async Threads
                w.DoWork += delegate (object s, DoWorkEventArgs args) 
                {
                    Upload(args.Argument.ToString());
                };
                w.RunWorkerAsync(path);
            }
