            var messages = new List<string>();
            Action<string> verbose = (text) => {
                messages.Add(text);
            }; // add logging message to buffer
            using (var dbContext = new MyDbContext(BuildOptionsBuilder(connectionString, inMemory), verbose))
            {
                 //..
            };
