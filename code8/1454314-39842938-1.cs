    var orderExpressions = new List<NHibernate.Criterion.Order>
    {
        NHibernate.Criterion.Order.Desc(
            Projections.SqlFunction(
                new SQLFunctionTemplate(NHibernateUtil.DateTime, 
                    "DateAdd(MINUTE, " + 
                    new SQLFunctionTemplate(NHibernateUtil.DateTime,
                        "DateDiff(MINUTE, 0, ?1)"
                    ) + 
                    ", 0)"),
                    NHibernateUtil.DateTime,
                    Projections.Property<DocumentTracking>(x => x.OrderDate)
            )
        ),
        NHibernate.Criterion.Order.Asc(Projections.Property<DocumentTracking>(x => x.Type))
    };
