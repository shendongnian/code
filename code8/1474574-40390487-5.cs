        static void Main(string[] args)
        {
            string filePath = @"FILE PATH";
            Task<string[]> task = Task.Run<string[]>(() => ReadFile(filePath));
            bool stopWhile = false;
            //if you want to not block the UI with Task.Wait() for the result
            // and you want to perform some other operations with the already read file
            Task continueTask = task.ContinueWith((x) => {
                string[] result = x.Result; //result of readed file
                foreach(var a in result)
                {
                    Console.WriteLine(a);
                }
                    
                stopWhile = true;
                });
            //here do other actions not related with the result of the file content
            while(!stopWhile)
            {
                Console.WriteLine("TEST");
            }
        }
        public static string[] ReadFile(string filePath)
        {
            List<String> lines = new List<String>();
            string line = "";
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                    lines.Add(line);
            }
            Console.WriteLine("File Readed");
            return lines.ToArray();
        }
