    OrderStatus statusAlias = null;        
    var tuples = Session.QueryOver<Order>()
                .JoinQueryOver(x => x.Status, () => statusAlias)
                .SelectList(list => list
                    .Select(x => x.Id)
                    .Select(x => statusAlias.Id)
                    .Select(x => statusAlias.Name))
                .List<object[]>();
    var result = tuples.Select(Convert);
    private OrderSummary Convert(object[] item) {
                return new OrderSummary
                {
                    Id = (long)item[0],
                    OrderStatus = new OrderStatus { Id = (long)item[1], Name = (string)item[2] }
                };
            }
