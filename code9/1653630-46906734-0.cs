    // this method is to recieve first request and also edit request..  
            [HttpGet]
            public async Task<IActionResult> Create(int id)
            {
              Products products = new Products();
              if(id == 0) //here you can write create part
               {
                  // code to bind something..
               }
              else //in else you can write edit part
               {
                  products = GetProductById(id); // this is to get edit data..
               }
             
             return View(products);
            }
        // this post method will recieve data while creating and updating.
            [HttpPost]
            public async Task<IActionResult> Create(Products products)
            {
             if(products.ProductId == 0) 
               {
                  CreateProduct(products); // record insertion procedure
               }
              else 
               {
                  UpdateProduct(products); // record update procedure
               }
            }
