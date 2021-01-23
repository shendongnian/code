    var criteria = session.CreateCriteria(typeof(RequestDetail))
        // the Course.Price comes from some collection
        // we have to JOIN it
        .CreateAlias("Course", "Course")// the first is property name, the second is alias
        .SetProjection(
            Projections.ProjectionList()
            .Add(Projections.RowCount(), "RowCount")
            .Add(Projections.Sum("Course.Price"), "Price")
            .Add(Projections.GroupProperty("RequestId"), "RequestId")
        )
        .AddOrder(Order.Asc("RequestId"))
        .SetResultTransformer(Transformers.AliasToBean<MyDTO>())
        ;
    var list = criteria.List<MyDTO>();
