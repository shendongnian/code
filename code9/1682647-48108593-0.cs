    List<Product> products = (from inventory in inventoryDetails.AsEnumerable()
                            select new Product
                            {
                                ean = !string.IsNullOrEmpty(inventory.ean) ? inventory.ean : null,
                                sku = !string.IsNullOrEmpty(inventory.sku) ? inventory.sku : null,
                                attributes = inventory.attributes.Select(x => new Attributes
                                {
                                    //Set properties
    
                                }).ToList()
                            }).ToList();
