    var publications = new List<Publication>
            {
                new Publication
                {
                    Products = new List<Product>
                    {
                        new Product {Category = 5},
                        new Product {Category = 6},
                        new Product {Category = 7}
                    }
                },
                new Publication
                {
                    Products = new List<Product>
                    {
                        new Product {Category = 2},
                        new Product {Category = 3},
                        new Product {Category = 4}
                    }
                },
                new Publication
                {
                    Products = new List<Product>
                    {
                        new Product {Category = 8},
                        new Product {Category = 9},
                        new Product {Category = 10}
                    }
                }
            };
            var query = publications.OrderByDescending(p => p.Products.Select(x => x.Category).FirstOrDefault()).ToList();
            query.ForEach(x => Console.WriteLine(x.ToString()));
