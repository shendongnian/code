    var fields = new ResultsetFields(1);
    fields.DefineField(OrderFields.Freight, 0, AggregateFunction.Sum);
    
    var bucket = new RelationPredicateBucket();
    bucket.PredicateExpression.Add(new FieldCompareSetPredicate(
        OrderFields.OrderId, null, OrderDetailFields.OrderId, null, 
        SetOperator.In, (OrderDetailFields.ProductId ==1)));
    
    DataTable dynamicList = new DataTable();
    
    using (var adapter = new DataAccessAdapter())
    {
        adapter.FetchTypedList(fields, dynamicList, bucket);
    }
