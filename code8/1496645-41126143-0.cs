            // modified and new products
            var result = table2
                        .Select(d2 => new { d2.Product, d2.Amount, d2.Address })
                        .Except(table1.Select(d1 => new { d1.Product, d1.Amount, d1.Address }));
            var deletedProducts = table1
                                 .Where(d => !table2.Select(d2 => d2.Product).Contains(d.Product))
                                 .Select(d1 => new { d1.Product, d1.Amount, d1.Address });
            result = result.Concat(deletedProducts);
