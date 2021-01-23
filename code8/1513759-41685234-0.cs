        public void checkTPFiles()
        {
            FileSystemWatcher fw = new FileSystemWatcher(@"F:\tmp");
            var fCheck = new FCheck(this);       // <= passes Form1 instance
            fw.Created += fCheck.tpCard_Created; // <= no static call anymore
            fw.EnableRaisingEvents = true;
        }
        public void populateTable(TpCard tpCard)
        {
            
        }
