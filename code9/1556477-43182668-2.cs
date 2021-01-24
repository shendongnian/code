        private static void Print(Dictionary<string, IEnumerable<IGrouping<string, MyClass>>> groupbydata)
        {
            foreach (var d1 in groupbydata)
            {
                Debug.WriteLine("Code : " + d1.Key);
                foreach (var d2 in d1.Value)
                {
                    Debug.WriteLine("Week number + Year: " + d2.Key);
                    foreach (var d3 in d2)
                    {
                        Debug.WriteLine("Date : " + d3.Date);
                    }
                }
            }
        }
