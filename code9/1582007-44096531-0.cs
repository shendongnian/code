                bool itemFind = false;
                string itemName = "";
                List<string> destinationArray = new List<string>();
    
                List<string> inputArrayList = new List<string>();
                inputArrayList.Add("Something One");
                inputArrayList.Add("Something[ABC] Two");
                inputArrayList.Add("Something[ABC] Three");
                inputArrayList.Add("Something Four Section 1");
                inputArrayList.Add("Something Four Section 2");
                inputArrayList.Add("Something Five");
                inputArrayList.Add("Other Text");
    
                List<string> searchingArrayList = new List<string>();
                searchingArrayList.Add("One");
                searchingArrayList.Add("Two");
                searchingArrayList.Add("Three");
                searchingArrayList.Add("Five");
                searchingArrayList.Add("Section 1");
                searchingArrayList.Add("Section 2");
    
                foreach (var itemInput in inputArrayList)
                {
                    foreach (var itemSearching in searchingArrayList)
                    {
                        if (itemInput.Contains(itemSearching) == true)
                        {
                            itemName = itemSearching;
                            itemFind = true;
                        }
                    }
                    if (itemFind)
                    {
                        destinationArray.Add(itemName);
                        itemFind = false;
                    }
                    else
                    {
                        destinationArray.Add(itemInput);
                    }
                }
    
                destinationArray.ToList().ForEach(x => Console.WriteLine(x));
                Console.ReadKey();
