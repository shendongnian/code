     return DataAccess.Find<Tuple<DateTime, Guid>>(DetachedCriteria.For<FooBarResult>()
        .Add(Restrictions.Eq("Task", st))
        .SetProjection(
            Projections.ProjectionList()
                .Add(
                    Projections.Property("FieldOne")
                )
                .Add(
                    Projections.Property("FieldTwo")
                )
        ).SetResultTransformer(Transformers.AliasToBeanConstructor(tupleConstructor))
    ).ToList();
