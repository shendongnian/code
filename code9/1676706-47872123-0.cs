    public class TextSectionsParser
    {
        private readonly string _delimiter;
        public TextSectionsParser(string delimiter)
        {
            _delimiter = delimiter;
        }
        public IEnumerable<IEnumerable<string>> ParseSections(IEnumerable<string> lines)
        {
            var result = new List<List<string>>();
            var currentList = new List<string>();
            
            foreach (var line in lines)
            {
                if (line == _delimiter)
                {
                    if(currentList.Any())
                        result.Add(currentList);
                    currentList = new List<string>();
                }
                else
                {
                    currentList.Add(line);
                }
            }
            if (currentList.Any() && !result.Contains(currentList))
            {
                result.Add(currentList);
            }
            return result;
        }
    }
