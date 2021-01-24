        private async Task<List<int>> ReturnInts()
        {
            return new List<int> { 5 };
        }
        public async Task<List<int>> PenanceFunction()
        {
            List<Task<List<int>>> tasks = new List<Task<List<int>>>();
            tasks.Add(ReturnInts());
            tasks.Add(ReturnInts());
            List<int> myResults = new List<int>();
            await Task.WhenAll(tasks);
            foreach(var t in tasks)
            {
                myResults.AddRange(t.Result);
            }
            return myResults;
        }
