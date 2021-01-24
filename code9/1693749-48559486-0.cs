        static void Main(string[] args)
        {
            var queue = new Queue<int>(10); //Capacity of Queue is 10
            Console.WriteLine("=== Writing to Queue ===");
            for (int i = 0; i < 23; ++i) //22 rounds for inserting data
            {
                DequeueIfFull(i, queue);
                Console.WriteLine("Inserting number {0} into Queue", i);
                queue.Enqueue(i); //Read and remove the first item in Queue
            }
            FlushQueue(queue); //Last time read all values from queue
            Console.ReadKey();
        }
        private static void DequeueIfFull(int i, Queue<int> queue)
        {
            var tenthItemInserted = (i != 0) && (i % 10 == 0);
            if (tenthItemInserted)
            {
                Console.WriteLine("Dequeuing from Queue");
                for (int j = 0; j < 10; ++j)
                {
                    Console.WriteLine("  Number dequeued on position {0} is {1}", j, queue.Dequeue());
                }
            }
        }
        private static void FlushQueue(Queue<int> queue)
        {
            Console.WriteLine();
            Console.WriteLine("=== Reading final Queue state ===");
            var index = 0;
            foreach (var itemInQueue in queue)
            {
                Console.WriteLine("At position {0} is number {1} ", index, itemInQueue);
                index++;
            }
        }
