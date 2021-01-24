    // Creates Product objects from array of records
    // At present, images are assumed void
    // When CSV data contains images, then this code will need changing slightly.
            var CSVProducts = from line in records
                              let columns = line.Split(',')
                              select new Product
                              {
                                  Id = int.Parse(columns[0]),
                                  Barcode = columns[13],
                                  Name = columns[1],
                                  CategoryName = CapitaliseWords(columns[9]),
                                  Description = columns[2],
                                  Price = decimal.Parse(columns[4])
                              };
            ProductsList = CSVProducts.ToList();
            var CSVCategories = File.ReadLines(path).Skip(1)
                               .Select(l => l.Split(new[] { ',' })[9])
                               .Where(category => category.Length > 0)
                               .Distinct(StringComparer.InvariantCultureIgnoreCase)
                               .Select(s => new Category { Name = CapitaliseWords(s) });
                CategoriesList = CSVCategories.ToList();
