             foreach (var p in products.ToList())
                {
                    var additives = p.Additives.ToList();
    
                    foreach (var a in additives)
                    {
                        if (a.Key.Equals(key))
                        {
                            productsAdditives.Add(p);   
                        }   
                    }
                }
