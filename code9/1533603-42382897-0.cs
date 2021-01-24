    // the following code is copied from the tutorial pointed at my question.
    // I just reduced it to the basics to make the answer short and simple
    public class Product {
        private string m_name;
        private int m_price;
    
        public Product(string name, int price) {
            m_name = name;
            m_price = price;
        }
    }
    
    public class Merchant {
        private List<Product> m_products;
        
        public Merchant() {
            m_products = new List<Product>;
            m_products.Add(new Product("Pen",25));
            m_products.Add(new Product("Pencil",30));
            m_products.Add(new Product("Notebook",15));
        }
    
        public List<Product> getProducts() {
             return m_products;
        }
    }
