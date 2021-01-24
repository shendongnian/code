     public class Item
     {
        //other properties
        public string ItemNum {get; set;}
        private List<Manufacturers> _Manufacturers
        private ApplicationContext() _context;
        public Item (string ItemNum = "some default text"){
           _context = new ApplicationContext();
           _Manufacturers = _context.Manufacturers.Where(i => i.Item == 
           this.ItemNum).ToList();
        }
        public List<Manufacturers> Manufacturers
        {
          get
          {
           return _Manufacturers;
          }
        }
     }
