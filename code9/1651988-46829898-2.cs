    public async Task DoSomething()
        {
            var ids = Enumerable.Range(1, 5);
            var myList = new List<Task<string>>();
            foreach (var id in ids)
            {
                myList.Add(CallApiAsync(id.ToString()));
            }
            await Task.WhenAll(myList);
            foreach (var task in myList)
            {
                Console.WriteLine(task.Result);
            }
        }
        public Task<string> CallApi(string id)
        {
            return Task.Run(() => id);
        }
