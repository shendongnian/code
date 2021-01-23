        public async Task TestItWithTimeout()
        {
            using (var rbt = new ProxyClass("localhost"))
            {
                var task = rbt.Recieve<TestObj>("Test McTesting");
                if (await Task.WhenAny(task, Task.Delay(TimeSpan.FromSeconds(30))) == task)
                {
                    var employee = await task;
                    Console.WriteLine($"{employee.Id} / {employee.Name} / {employee.Dexcription}");
                }
            }
        }
