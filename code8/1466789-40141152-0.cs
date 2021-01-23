        static void Main()
        {
            // New Queue of integers.
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);   // Add 1 to the end of the Queue.
            q.Enqueue(2);  // Then add 2. 1 is at the start.
            q.Enqueue(3);  // Then add 3.
            q.Enqueue(4);  // Then add 4.
            q.Dequeue(); // The integer is removed from the beginning of the Queue.
            Console.WriteLine(q.Peek()); // to take a look of the 1 integer in queue
           
            Console.ReadLine();
        }
