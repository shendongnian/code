       public class RootObject
        {
            public string Token { get; set; }
            public File file { get; set; }
        }
        
        public class File
        {
            public File()
            {
                this.itemsDeatails = new ItemsDeatails();
            }
            public string nameLocator { get; set; }
            public ItemsDeatails itemsDeatails { get; set; }
        }
        
        public class ItemsDeatails
        {
            public ItemsDeatails(){
             this.ItemsFromFile = new List<ItemsFromFile>();
            }
            public List<ItemsFromFile> ItemsFromFile { get; set; }
        }
        
        public class ItemsFromFile
        {
            public ItemsFromFile(){
             this.products = new List<Product>();
            }
    
            public List<Product> products { get; set; }
    
        }
    
        public class Product {
            public string ASIN { get; set; }
            public string Title { get; set; }
        }
