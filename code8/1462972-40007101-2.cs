            string[] testStr = new string[] { null, "", "test" };
            foreach (var item in testStr)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine("item was null");
                }
            }
            Console.ReadKey();
