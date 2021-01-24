        IEnumerable<object> obs;
        IEnumerable<object> data;
        Dictionary<string, object> dataCache = new Dictionary<string, object>();
        var dataIterator = data.GetEnumerator();
        foreach (var ob in obs)
        {
            var obText = ob.ToString();
            object matchingDataItem = null;
            if (!dataCache.TryGetValue(obText, out matchingDataItem))
            {
                while (dataIterator.MoveNext())
                {
                    var currentData = dataIterator.Current;
                    var currentDataText = currentData.ToString();
                    dataCache.Add(currentDataText, currentData);
                    if (currentDataText == obText)
                    {
                        matchingDataItem = currentData;
                        break;
                    }
                }
            }
            if (matchingDataItem != null)
            {
                Console.WriteLine("Matching item found for " + obText);
            }
            else
            {
                throw new Exception("No matching data found.");
            }
        }
