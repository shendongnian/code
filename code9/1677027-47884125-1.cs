    public List<string> GetFields(string line)
    {
        var list = new List<string>();
    
        for (var i = 0; i < line.Length; i++)
        {
            var firstQuote = line.IndexOf('"', i);
            var firstComma = line.IndexOf(',', i);
    
            if (firstComma >= 0)
            {
                // first comma is before the first quote, then its just a standard field
                if (firstComma < firstQuote || firstQuote == -1)
                {
                    list.Add(line.Substring(i, firstComma - i));
                    i = firstComma;
                    continue;
                }
    
                // We have found quote so look for the next comma afterwards
                var nextQuote = line.IndexOf('"', firstQuote + 1);
                var nextComma = line.IndexOf(',', nextQuote + 1);
    
                // if we found a comma, then we have found the end of this field
                if (nextComma >= 0)
                {
                    list.Add(line.Substring(i, nextComma - i));
                    i = nextComma;
                    continue;
                }
            }
                
            list.Add(line.Substring(i)); // if were are here there are no more fields
            break;
    
        }
        return list;
    }
