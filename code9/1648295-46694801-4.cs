        public void MyProdMethod()
        {
            // I have more logic in my real method, serialization, handling errors
            Console.WriteLine("In my method");
            Task.Factory.StartNew(() => {
                Thread.Sleep(2000);
                Console.WriteLine("Setting status");
                Status = "Yes I set it";
            }, CancellationToken.None).Wait();
            Console.WriteLine("Finishing my method");
        }
