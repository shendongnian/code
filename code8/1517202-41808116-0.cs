    public class ComboItem
    {
        public string Text { get; set; }
        public int ID { get; set; }
        public string Description { get; set; }
    
        public override string ToString()
        {
            return Text;
        }
    }
