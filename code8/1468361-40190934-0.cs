    public class Order
    {
        public int Id { get; set; }
        public List<Items> Items { get; set; }
        ...
        public int TotalPrice 
        {
            get
            {
                 return Items == null ? 0 : Items.Sum(p => p.Price);
            }
        }
    }
