    private static void Main(string[] args)
        {
            var file = new StreamReader(@"C:\test\csvTest.csv");
            string line;
            var itemsJson = new List<string>();
            file.ReadLine();
            while ((line = file.ReadLine()) != null)
            {
                var sb = new StringBuilder();
                var fields = line.Split(',');
                sb.Append(GetKeyValueJson("UserId", fields[0]));
                for (var i = 1; i < fields.Length; i += 3)
                {
                    var x = (i + 3) / 3;
                    sb.Append(GetKeyValueJson($"Thing {i + x} ID", fields[i]));
                    sb.Append(GetKeyValueJson($"Thing {i + x} ID", fields[i + 1]));
                    sb.Append(i + 3 == fields.Length
                        ? GetKeyValueJson($"Thing {i + x} ID", fields[i + 2], true)
                        : GetKeyValueJson($"Thing {i + x} ID", fields[i + 2]));
                }
                itemsJson.Add(WrapJson(sb.ToString()));
            }
            var json = WrapItems(itemsJson);
            Console.ReadLine();
        }
        private static string GetKeyValueJson(string id, string value, bool lastPair = false)
        {
            var sb = new StringBuilder();
            sb.Append('"');
            sb.Append(id);
            sb.Append('"');
            sb.Append(':');
            sb.Append('"');
            sb.Append(value);
            sb.Append('"');
            if (!lastPair)
                sb.Append(',');
            return sb.ToString();
        }
        private static string WrapJson(string s)
        {
            var sb = new StringBuilder();
            sb.Append('{');
            sb.Append(s);
            sb.Append('}');
            return sb.ToString();
        }
        private static string WrapItems(List<string> jsonList)
        {
            var sb = new StringBuilder();
            sb.Append('"');
            sb.Append("Items");
            sb.Append('"');
            sb.Append(':');
            sb.Append('[');
            sb.Append(jsonList.Aggregate((current, next) => current + "," + next));
            sb.Append(']');
            return WrapJson(sb.ToString());
        }
    }
