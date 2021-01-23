        public static List<Dictionary<string, string>> ConvertToDictionaryList(this Table dt)
        {
            var lstDict = new List<Dictionary<string, string>>();
            if (dt!=null)
            {
                var headers = dt.Header;
                foreach (var row in dt.Rows)
                {
                    var dict = new Dictionary<string, string>();
                    foreach (var header in headers)
                    {
                        dict.Add(header, row[header]);
                    }
                    lstDict.Add(dict);
                }
            }
            return lstDict;
        }
