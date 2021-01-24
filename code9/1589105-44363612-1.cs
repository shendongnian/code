        public static void Main()
        {
            var line = File
              .ReadLines(@"C:\\M\send.txt") // We don't want All lines to be in memory
              .LastOrDefault();
            string username = ""; // or null
            string password = ""; // or null
            if (line != null)
            {
                string[] tokens = line.Split(',');
                string user = tokens[0];
                string pass = tokens[1];
                username = user;
                password = pass;
            }
            //TODO: you may want to add "else" here (i.e. the file is empty case)
