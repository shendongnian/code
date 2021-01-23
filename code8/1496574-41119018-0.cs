    public MyClass Get() {
       return new MyClass {
          Products = db.Products.ToList()
       };        
    }
