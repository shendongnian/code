        public class Data
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        //Takes data list and desired lenght of merged string data
        public static List<string> MergeData(List<Data> data, int maxLenght)
        {
            List<string> mergedData = new List<string>();
            foreach (var d in data)
            {
                //Calculates how many spaces are needed to be inserted between Name and Price
                int numberOfSpacesNeeded = maxLenght - (d.Name.Length + d.Price.ToString().Length);
                //Builds new string with merged data
                var sb = new StringBuilder();
                sb.Append(d.Name)
                    .Append(' ', numberOfSpacesNeeded)
                    .Append(d.Price.ToString());
                mergedData.Add(sb.ToString());
            }
            return mergedData;
        }
