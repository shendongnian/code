            var productList = new List<Product>
            {
                new Product
                {
                    product_id = 1,
                    name = "test1",
                    company = new List<CompaniesProvideProduct>
                    {
                        new CompaniesProvideProduct
                        {
                            company_id = 1,
                            price = 1.99m,
                            product_id = 1
                        }
                    }
                },
                new Product
                {
                    product_id = 2,
                    name = "test2",
                    company = new List<CompaniesProvideProduct>
                    {
                        new CompaniesProvideProduct
                        {
                            company_id = 2,
                            price = 1.99m,
                            product_id = 2
                        }
                    }
                }
            };
