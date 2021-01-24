        public static List<string> MergeData(List<Data> data)
        {
            int maxLenght = data.Max(x => x.Name.Length + x.Price.ToString().Length) + 1;
            List<string> mergedData = new List<string>();
            foreach (var d in data)
            {
                string name = d.Name;
                int numberOfSpacesNeeded = maxLenght - (d.Name.Length + d.Price.ToString().Length);
                var sb = new StringBuilder();
                sb.Append(name)
                    .Append(' ', numberOfSpacesNeeded)
                    .Append(d.Price.ToString());
                mergedData.Add(sb.ToString());
            }
            return mergedData;
        }
