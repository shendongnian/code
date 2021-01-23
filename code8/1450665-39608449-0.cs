    var func = Projections.SqlFunction(new VarArgsSQLFunction(NHibernateUtil.Double, "(", "-", ")"), NHibernateUtil.DateTime, Projections.SqlFunction("sysdate", NHibernateUtil.DateTime), Projections.Property<AdministrativeCaseEO>(c => c.EffectiveCasePeriod.EffectiveStartDate));
    var parfunc = Projections.SqlFunction(new VarArgsSQLFunction(NHibernateUtil.Double, "(", "*", ")"), NHibernateUtil.Decimal, func, Projections.Constant(24));
    var conjunction = Restrictions.Conjunction()
    `.Add(Restrictions.Eq(Projections.Property<RepositoryItemDO>(c => c.RepositoryType ), yourRefType))
    .Add(Restrictions.IsNotNull(Projections.Property<RepositoryItemDO>(c => c.TargetEncryption)))
    .Add(Restrictions.IsNotNull(Projections.Property<RepositoryItemDO>(c => c.TargetStorage)))
    .Add(dateConj);
