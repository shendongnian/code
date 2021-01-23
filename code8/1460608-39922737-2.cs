    var result = Establishments.Select(e => new
                {
                    ID = e.ID,
                    Name = e.Name,
                    Category = e.Category.Name,
                    XAdress = e.XAdress,
                    YAdress = e.YAdress,
                    CompanyName = e.Company.Name,
                    ProductsSelling = e.ProductsSelling?.Select(p => new /* note the '?' operator*/
                    {
                        ID = p.ID,
                        Name = p.Name,
                        Category = p.Category.Name,
                        Price = p.Price,
                        Additives = p.PossibleAdditives.Select(a => new
                        {
                            ID = a.ID,
                            Name = a.Name,
                            Price = a.Price
                        })
                    })                    
                });
