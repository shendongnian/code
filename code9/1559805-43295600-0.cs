            var intList = new List<int>{5,6};
            int z =0;
            foreach(var intItem in intList)
            {
                try
                {
                    z = intItem / 0;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Catch reached");
                }
                finally
                {
                    Console.WriteLine("Finally reached");
                }
            }
