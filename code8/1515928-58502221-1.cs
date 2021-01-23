        public static List<Dictionary<string, string>> ConvertToDictionaryList(this Table dt)
        {
            var lstDict = new Dictionary<string, List<string>>();
            if (dt != null)
            {
                var headers = dt.Header;
                foreach (var row in dt.Rows)
                {
                    foreach (var header in headers)
                    {
                        if (lstDict.ContainsKey(header))
                        {
                            lstDict[header].Add(row[header]);
                        }
                        else
                        {
                            lstDict.Add(header, new List<string> { row[header] });
                        }
                    }
                }
            }
            return lstDict;
            
        }
