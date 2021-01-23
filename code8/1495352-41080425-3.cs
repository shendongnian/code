    RefVal<int> data = new RefVal<int>(0); //the variable "data" will be a shared variable
    Producer producer = new Producer(hasData, hasSpace, data);
    Consumer consumer = new Consumer(hasData, hasSpace, data);
    // ...
    class Producer
    {
        private RefVal<int> data;
        // ...
        public Producer(Semaphore hasData, Semaphore hasSpace, RefVal<int> data)
        {
            this.hasData = hasData;
            this.hasSpace = hasSpace;
            this.data = data;
        }
        public void Produce()
        {
            while (true)
            {
                hasSpace.WaitOne();
                this.data.Value = rnd.Next(0, 100); // set value to .Value
                Console.WriteLine("The producer made: " + this.data);
                Thread.Sleep(5000);
                hasData.Release();
            }
        }
    }
    class Consumer
    {
        private Semaphore hasData;
        private Semaphore hasSpace;
        private RefVal<int> data;
        public Consumer(Semaphore hasData, Semaphore hasSpace, RefVal<int> data)
        {
            this.hasData = hasData;
            this.hasSpace = hasSpace;
            this.data = data;
        }
        //...
    }
