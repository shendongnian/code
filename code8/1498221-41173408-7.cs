        public async Task TestIt()
        {
            using (var rbt = new ProxyClass("localhost"))
            {
                var employee = await rbt.Recieve<TestObj>("Test McTesting");
                Console.WriteLine($"{employee.Id} / {employee.Name} / {employee.Dexcription}");
            }
        }
