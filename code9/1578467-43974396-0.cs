    public Dictionary<int, Order> GetOrderLookup()
    {
        var lookup = new Dictionary<int, Order>();
    
        const string sql = @"   SELECT  o.id,
                                        o.order_reference,
                                        o.order_status,
    
                                        ol.id,
                                        ol.order_id,
                                        ol.product_number,
    
                                        ols.id,
                                        ols.order_line_id,
                                        ols.size_name
                                FROM    orders_mstr o
                                JOIN    order_lines ol ON o.id = ol.order_id
                                JOIN    order_line_size_relations ols ON ol.id = ols.order_line_id";
    
        List<Order> orders = null;
        using (var connection = OpenConnection(_connectionString))
        {
            orders = connection.Query<Order, OrderLine, OrderLineSize, Order>(sql, (order, orderLine, orderLizeSize) =>
            {
                orderLine.OrderLineSizes = new List<OrderLineSize> { orderLizeSize };
                order.OrderLines = new List<OrderLine>() { orderLine };
                return order;
            },
            null, commandType: CommandType.Text).ToList();
        }
    
        if (orders == null || orders.Count == 0)
        {
            return lookup;
        }
    
        foreach (var order in orders)
        {
            var contians = lookup.ContainsKey(order.id);
            if (contians)
            {
                var newLinesToAdd = new List<OrderLine>();
                var existsLines = lookup[order.id].OrderLines;
                foreach (var existsLine in existsLines)
                {
                    foreach (var newLine in order.OrderLines)
                    {
                        if (existsLine.id == newLine.id)
                        {
                            existsLine.OrderLineSizes.AddRange(newLine.OrderLineSizes);
                        }
                        else
                        {
                            newLinesToAdd.Add(newLine);
                        }
                    }
                }
                existsLines.AddRange(newLinesToAdd);
            }
            else
            {
                lookup.Add(order.id, order);
            }
        }
    
        return lookup;
    }
