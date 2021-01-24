    public class ListParser
    {
        public int x;
        public int y;
        public string value;
        public bool IsValid = false;
        public ListParser(List<string> row)
        {
            if (row != null && row.Count >= 3 && int.TryParse(row[0], out x) && int.TryParse(row[1], out y))
            {
                IsValid = true;
                value = row[2];
            }
        }
    }
