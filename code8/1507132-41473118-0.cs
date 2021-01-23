    public class InventoryViewModel
    {
        public string Name { get; set; }
        public int Inventory_No { get; set; }
        public int Supplier_No { get; set; }
        public List<Supplies>
        {
            get
                {
                     return <your DAL>.Supplies.All().ToList();
                }
        }
    }
