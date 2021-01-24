    using System.Linq;
    collectionCarts.Select(c => c.OrderList)
                   .Select(ol => 
                           ol.Select(o => o.Customer)
                             .Where(c => c.CustomerId == 2)
                    )
                   .SelectMany(c => c);
