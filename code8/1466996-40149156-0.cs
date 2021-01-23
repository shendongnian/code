        public void NestedDictIteration(Dictionary<string,object> nestedDict)
        {
            foreach (string key in nestedDict.Keys)
            {
                Console.WriteLine(key);
                object nextLevel = nestedDict[key];
                if(nextLevel == null)
                {
                    continue;
                }
                NestedDictIteration((Dictionary<string, object>)nextLevel);
            }
        }
