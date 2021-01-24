     List<Product> products = inventoryDetails.Select(inventory => new Product
            {
                ean = !string.IsNullOrEmpty(inventory.ean) ? inventory.ean : null,
                sku = !string.IsNullOrEmpty(inventory.sku) ? inventory.sku : null,
                attributes = inventory.attributes
                // if you want to set properties uncomment below lines and comment above line
                //attributes = inventory.attributes.Select(y => new Attributes
                //{
                    ////Set properties
    
                //}).ToList()
            }).ToList();
