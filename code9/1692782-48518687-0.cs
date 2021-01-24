    foreach (var value in allProducts)
            {
                string ID = value.ID.ToString();
                string Category = value.Category.ToString();
                string Description = value.Description.ToString();
                total += (ID.Length + Category.Length + Description.Length);
                Console.WriteLine(total);
            }
