    public class Items : Attribute
    {
        public bool Last { get; set; }
        public Items(bool last = false)
        {
            this.Last = last;
        }
    }
