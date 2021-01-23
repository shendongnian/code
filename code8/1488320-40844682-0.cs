            Dictionary<string, Comparison<decimal>> comparer = new Dictionary<string, Comparison<Product>>
            {
                ["asc"] = (a, b) => a.Price.CompareTo(b.Price),
                ["desc"] = (a, b) => b.Price.CompareTo(a.Price)
            };
            var lower = 500;
            var upper = 1000;
            var direction = "Asc";
            products.Where(p => p.Price >= lower && p.Price <= upper).ToList().Sort(comparer[direction.ToLower()]);
