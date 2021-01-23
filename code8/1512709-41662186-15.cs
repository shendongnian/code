    private class SelectionData
    {
        public static SelectionData FromStartAndEnd(
            Int32 start,
            Int32 end)
        {
            return new SelectionData(
                start: start,
                length: end - start);
        }
        public SelectionData(TextBoxBase tb)
            : this(
                start: tb.SelectionStart,
                length: tb.SelectionLength)
        {            }
        
        public SelectionData(Int32 start, Int32 length)
        {
            this.Start = start;
            this.Length = length;
        }
        public readonly Int32 Start, Length;
        public Int32 End
        {
            get
            {
                return this.Start + this.Length;
            }
        }
    }
