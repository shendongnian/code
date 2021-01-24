        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(myTimer_Tick);
            timer.Interval = (int) new TimeSpan(0, 0, 1).TotalMilliseconds;
            stopWatch = new Stopwatch();
    
            // Set the path to wherever you want that the user has write permissions
            var dataPath = Path.Combine(Path.GetDirectoryName(Uri.UnescapeDataString(
                new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path)), 
                "datastore.dat");
            dataStore = DataStore.Load(dataPath);
            UpdateElapsedTime();
        }
