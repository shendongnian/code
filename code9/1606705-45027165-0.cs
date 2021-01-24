    public sealed class  MyListBox:CheckedListBox
    {
        public MyListBox()
        {
            ItemHeight = 30;
        }
        public override int ItemHeight { get; set; }
    }
