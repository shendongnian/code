    var data = (from a in cData.OrderDetails
                join b in cData.ItemMaster on a.OrderItemId equals b.ItemID
                group a.OrderQty by new { a.OrderItemId, b.ItemName } into g
                select new {
                    ItemName = g.Key.ItemName,
                    ItemQty = Convert.ToInt16(g.Sum())
                }).Select((item,index) => new ConsolidatedOrder {
                    Sno = index,
                    ItemName = item.ItemName,
                    ItemQty = item.ItemQty
                };
