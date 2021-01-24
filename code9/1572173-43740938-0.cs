     var list = new List<ProductInfo> {
                    new ProductInfo { Id = 1, Name = "XXX", Option = "A"},
                    new ProductInfo { Id = 1, Name = "XXX", Option = "B" },
                    new ProductInfo { Id = 2, Name = "DEB", Option = "A" },
                    new ProductInfo { Id = 2, Name = "DEB", Option = "B"},
                    new ProductInfo { Id = 2, Name = "DEB", Option = "C" },
                    new ProductInfo { Id = 3, Name = "ZZZ", Option = "D" }
    
                };
    
                var x = from p in list
                        group p by new { p.Id, p.Name, p.Option } into g
                        select new
                        {
                            Id = g.Key.Id,
                            Name = g.Key.Name,
                            Count = list.Count(m => m.Name == g.Key.Name)
                        };
                var t = x.Distinct();
