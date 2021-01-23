        class Item
        {
            public string title;
        }
        static void Main(string[] args)
        {
            var testList = new List<Item>
            {
                new Item { title = "Blah" },
                new Item { title = "Blah" },
                new Item { title = "Blah" },
                new Item { title = null },
                new Item { title = null },
                new Item { title = "test" },
                new Item { title = "test" },
                new Item { title = "test" },
                new Item { title = "test" }
            };
            
            var listCounts = testList.GroupBy(item => item.title);
            foreach (var count in listCounts)
            {
                Console.WriteLine("{0}: {1}", count.Key ?? string.Empty, count.Count());
            }
            Console.ReadKey();
        }
