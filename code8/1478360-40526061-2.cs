    var projectionList = Projections.ProjectionList()
        .Add(Projections.RowCount(), "RowCount")
        .Add(Projections.Sum("Price"), "Price")
        .Add(Projections.GroupProperty("StatusId"), "StatusId")
        .Add(Projections.SqlGroupProjection(
                "LastName + ' ' + FirstName as ClientName",
                "LastName + ' ' + FirstName",
                new string[] {"ClientName"}, 
                new IType[] {NHibernate.NHibernateUtil.String}) 
            , "ClientName")
