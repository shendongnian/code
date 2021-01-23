    public partial class Bar: ICloneable
    {
        public object Clone()
        {
            var bar = new Bar();
            bar.Name = Name;
            return bar;
        }
    }
