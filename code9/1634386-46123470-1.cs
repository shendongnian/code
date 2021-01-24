    public class SelectMethodCallItem
    {
        public SelectMethodCallItem(String text)
        {
            Text = text;
            SelStart = text.IndexOf('(');
            SelEnd = text.IndexOf(')');
            if (SelStart > -1 && SelEnd > -1)
            {
                ++SelStart;
                ++SelEnd;
            }
            else
            {
                SelStart = SelEnd = -1;
            }
        }
        public String Text { get; set; }
        public int SelStart { get; private set; }
        public int SelEnd { get; private set; }
        public int SelLEngth => (SelEnd - SelStart) - 1;
        public bool HasSelection => SelStart > -1 && SelEnd > -1;
    }
