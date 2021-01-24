            var intList = new List<int>{5};
            foreach(var intItem in intList)
            {
                try
                {
                  if(intItem == 5)
                    break;
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
