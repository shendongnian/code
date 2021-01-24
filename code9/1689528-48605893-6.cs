    public class Quiz
    {
        public Quiz() { Ranges = new List<SelectionRange>(); }
        public string Text { get; set; }
        public List<SelectionRange> Ranges { get; private set; }
        public string Render()
        {
            var content = new StringBuilder(Text);
            for (int i = Ranges.Count - 1; i >= 0; i--)
            {
                content.Remove(Ranges[i].Start, Ranges[i].Length);
                var length = Ranges[i].Length;
                var replacement = $@"<input id=""q{i}"" 
                    type=""text"" class=""editable""
                    maxlength=""{length}"" 
                    style=""width: {length*1.162}ch;"" />";
                content.Insert(Ranges[i].Start, replacement);
            }
            var result = string.Format(Properties.Resources.Template, content);
            return result;
        }
    }
    public class SelectionRange
    {
        public SelectionRange(int start, int length)
        {
            Start = start;
            Length = length;
        }
        public int Start { get; set; }
        public int Length { get; set; }
    }
