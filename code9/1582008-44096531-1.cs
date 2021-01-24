            string itemName = "";
            List<string> destinationArray = new List<string>();
            List<string> inputArrayList = new List<string>();
            inputArrayList.Add("Something One");
            inputArrayList.Add("Something [ABC] Two");
            inputArrayList.Add("Something [ABC] Three");
            inputArrayList.Add("Something Four Section 1");
            inputArrayList.Add("Something Four Section 2");
            inputArrayList.Add("Something Five");
            inputArrayList.Add("Other Text");
            List<string> allWordList = new List<string>();
            foreach (var item in inputArrayList)
            {
                allWordList.AddRange(item.Split(' ').ToList());
            }
            List<string> searchingArrayList = new List<string>();
            searchingArrayList = allWordList.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key).ToList();
            foreach (var itemInput in inputArrayList)
            {
                itemName = itemInput;
                foreach (var itemSearching in searchingArrayList)
                {
                    itemName = itemName.Replace(itemSearching, "");
                }
                destinationArray.Add(itemName);
            }
            destinationArray.ToList().ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
