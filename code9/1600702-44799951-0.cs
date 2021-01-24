    public class Item
    {
        public int Prop1 { get; set; }
        public bool IsValid{ get; set; }
        public Item(string value)
        {
            int temp;
            if (int.TryParse(value, out temp))
            {
                Prop1 = temp;
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
        }
    }
