        static void Main(string[] args)
        {
            Console.WriteLine(Convert("one,two,three,four,five,six,seven", 3)); 
        }
        public static string Convert(string inputString, int columnCount)
        {
            var resultBuilder = new StringBuilder();
            var entries = inputString.Split(',');
            var currentCol = 0;
            inputString = inputString.Replace(", ", ",");
            
            while (currentCol * columnCount < entries.Length)
            {
                var columnEntries = entries.Skip(currentCol * columnCount).Take(columnCount);
                var columnEntriesString = string.Join(", ", columnEntries);
                resultBuilder.Append($"[{columnEntriesString}],");
                currentCol++;
            }
            return resultBuilder.ToString().TrimEnd(' ',',');
        }
