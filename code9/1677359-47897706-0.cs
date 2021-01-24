    public class DataGridViewModel
    {   
        public int ID { get; set; }
    
        public string Name { get; set; }
    
        public int Type_ID { get; set; }
    
        public decimal Price { get; set; }
    
        public string Descryption { get; set; }
    
        public int Available_amount { get; set; }
    	
    	public DataGridViewModel()  
        {    
        }
    }
    public void GetProducts()
    {
        using (var db = new SklepContext())
        {
            var data = db.Products.Select(r => new DataGridViewModel()
            {
                ID  = r.ID,
                Name = r.Name,
                Type_ID = r.Type_ID,
                Price = r.Price,
                Descryption = r.Descryption,
                Available_amount = r.Available_amount
            }).ToList();
            dataGridViewBrowse.DataSource = data;
        }
    }
