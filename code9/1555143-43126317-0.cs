     var totalOrders = "Beans - 1\nMeat balls - 1\nBrown bread - 2\nBeans - 2\nBanana slice - 1\nSteak with rice - 1\nBrown bread - 1\n";
     var DictionaryHolder = new Dictionary<string, int>();
     //Split initial string into array and remove empties
     string[] initialArray = totalOrders.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var item in initialArray)
            {
                // Get the string Key or Entree
                string key = item.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();
                //  Get the Count of Portions
                int count = int.Parse(item.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim());
                // check if Dictionary has the key already if not add it
                if (!DictionaryHolder.ContainsKey(key))
                {
                    DictionaryHolder.Add(key, count);
                }
                else
                {
                    // If the dictionary already had that key increase portion count by amount ordered.
                    DictionaryHolder[key] = DictionaryHolder[key] + count;
                }
            }
