    for (int max = 10000; max <= 10000000; max *= 10)
            {
                List<string> list = new List<string>();
                LinkedList<string> linkedlist = new LinkedList<string>();
                Queue<string> queue = new Queue<string>();
                HashSet<string> hashset = new HashSet<string>();
                string[] array = new string[max];
    
                Random rand = new Random();
                string value;
    
                DateTime start = DateTime.Now;
                for (int i = 0; i < max; ++i)
                    list.Add(rand.Next().ToString());
                for (int i = 0; i < max; ++i)
                    value = list[i];
                DateTime dtlist = DateTime.Now;
    
                for (int i = 0; i < max; ++i)
                    linkedlist.AddLast(rand.Next().ToString());
                var head=linkedlist.First;
                for (int i = 0; i < max; ++i)
                {
                    value = head.Value;
                    head = head.Next;
                }
                DateTime dtlinkedlist = DateTime.Now;
    
                for (int i = 0; i < max; ++i)
                    queue.Enqueue(rand.Next().ToString());
                for (int i = 0; i < max; ++i)
                    value = queue.Dequeue();
                DateTime dtqueue = DateTime.Now;
    
                for (int i = 0; i < max; ++i)
                    hashset.Add(rand.Next().ToString());
                var ihash=hashset.GetEnumerator();
                for (int i = 0; i < max; ++i)
                {
                    value = ihash.Current;
                    ihash.MoveNext();
                }
                DateTime dthashset = DateTime.Now;
    
                for (int i = 0; i < max; ++i)
                    array[i] = rand.Next().ToString();
                for (int i = 0; i < max; ++i)
                    value = array[i];
                DateTime dtarray = DateTime.Now;
    
    
                Console.WriteLine("List " + list.Count + ": " + new TimeSpan(dtlist.Ticks - start.Ticks).TotalSeconds);
                Console.WriteLine("LinkedList " + linkedlist.Count + ": " + new TimeSpan(dtlinkedlist.Ticks - dtlist.Ticks).TotalSeconds);
                Console.WriteLine("Queue " + queue.Count + ": " + new TimeSpan(dtqueue.Ticks - dtlinkedlist.Ticks).TotalSeconds);
                Console.WriteLine("HashSet " + hashset.Count + ": " + new TimeSpan(dthashset.Ticks - dtqueue.Ticks).TotalSeconds);
                Console.WriteLine("Array " + array.Length + ": " + new TimeSpan(dtarray.Ticks - dthashset.Ticks).TotalSeconds);
                Console.WriteLine();
            }
