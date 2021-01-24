    public class ComboBoxPair
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public ComboBoxPair(string display, int idx)
        {
            Text = display;
            Index = idx;
        }
    }
