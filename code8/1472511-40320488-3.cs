        List<Procuct> list = new List<Procuct>();
        using (var reader = new StreamReader(@"Budget.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {               
                var temp = line.Split(" ");
                list.Add(new Product{
                    ProductId = temp[0],
                    ProductName = temp[1],
                    CustomerId = temp[2],
                    CustomerName = temp[3],
                    Amount = temp[4]
                });
            }
        }  
