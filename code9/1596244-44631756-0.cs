    var data = new List<Category> {       
       new Category { Id = 2, Name = "Plastic" }
          .WithProduct(3, "Nail")
          .WithProduct(4, "Key"),
       new Category { Id = 1, Name = "Plastic" } 
          .WithProducts(  
              new Product { Id = 1, Name = "Doll" }
              new Product { Id = 2, Name = "Pen" }
          ),
       new Category { Id = 3, Name = "Paper" }
          .WithProduct( new Product { Id = 2, Name = "Book" } )
    };
