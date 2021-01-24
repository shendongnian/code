    private static string FilterConnectionString(string connectionStringEntity, bool useProvider = true)
            {
                string result = "";
                string[] split = connectionStringEntity.Split(new char[2] { ';', '"' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var item1 in split)
                {
                    string item = item1.Trim();
                    if (item.ToLower().StartsWith("data source") ||
                       item.ToLower().StartsWith("initial catalog") ||
                       item.ToLower().StartsWith("user id") ||
                       item.ToLower().StartsWith("password") ||
                       item.ToLower().StartsWith("multipleactiveresultSets"))
                        result += item + ";";
                }
                return useProvider ? result + "provider=System.Data.SqlClient" : result;
            }
