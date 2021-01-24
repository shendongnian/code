            string[] myList = { "Item One", "Item Two", "Item Three" };
            Dictionary<string, object> myDictionary = new Dictionary<string, object>();
            myDictionary.Add("DictionaryItem", myList);
            //Short Hand
            foreach (var item in new List<string>((string[])myDictionary.First(m => m.Key == "DictionaryItem").Value))
            {
                Console.WriteLine(item);
            }
            //or Long Hand version
            KeyValuePair<string, object> element = myDictionary.First(m => m.Key == "DictionaryItem");
            List<String> listItem = new List<string>((string[])element.Value);
            foreach (var item in listItem)
            {
                Console.WriteLine(item);
            }
