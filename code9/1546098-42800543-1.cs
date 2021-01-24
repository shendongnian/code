                var orders = (from o in orders2
                              where o.OrderStatus == "Placed"
                              orderby o.OrderDate
                              select new { o.OrderedBy.FirstName, o.OrderedBy.LastName }).Distinct();
                foreach (var x in orders)
                {
                    Console.WriteLine(x.FirstName + " " + x.LastName);
                }
                Console.WriteLine(orders2.Sum(order => order.OrderItems.Select(item =>
                {
                    Console.WriteLine(item.Price);
                    return (double)(item.QtyOrdered * item.Price);
                }).Sum()));
