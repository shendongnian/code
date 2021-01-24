        Dictionary<int, string> fruit = new Dictionary<int, string>();
        fruit.Add(1, "Apple");
        fruit.Add(2, "Oranges");
        fruit.Add(3, "Pineapple");
        private List<string> getSubGroupPerID()
        {
            List<string> outcome = new List<string>();
            List<int> keys = getSubGroupsBelongingToUser();
            if(keys.Count > 0)
            {
                foreach(int key in keys)
                {
                    outcome.Add(fruit[key]);
                }
            }      
            else
            {
                outcome.Add("All");
            }
            return outcome;
        }
