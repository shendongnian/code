    List<int> listLength = new List<int>(10)
            {
                1, 2, 3, 4, 5
            };
            // 5
            Console.WriteLine(listLength.Count);
            // 10
            Console.WriteLine(listLength.Capacity);
            listLength.AddRange(new[] { 6, 7, 8, 9, 10 });
            // 10
            Console.WriteLine(listLength.Count);
            // 10
            Console.WriteLine(listLength.Capacity);
            listLength.AddRange(new[] { 11, 12, 13, 14, 15 });
            // 15
            Console.WriteLine(listLength.Count);
            // 20
            Console.WriteLine(listLength.Capacity);
            for (int i = 0; i < 10; i++)
            {
                listLength.RemoveAt(0);
            }
            // 5
            Console.WriteLine(listLength.Count);
            // Still 20 - as you can see, we decreased Count to the original number of items
            // but Capacity didn't shrink to its original amount
            Console.WriteLine(listLength.Capacity);
