    var query = Session.QueryOver<CrmContact>()
        .Where(x => x.Account.ID == account.ID && x.IsActive && x.IsContact);    
    query.And(Restrictions.Disjunction()
       .Add(Restrictions.InsensitiveLike(Projections.Property<CrmContact>(c => c.FirstName),
            filtString, MatchMode.Anywhere))
       .Add(Restrictions.InsensitiveLike(Projections.Property<CrmContact>(c => c.LastName),
            filtString, MatchMode.Anywhere))
       .Add(Restrictions.InsensitiveLike(Projections.Property<CrmContact>(c => c.Email),
            filtString, MatchMode.Anywhere))
       .Add(Restrictions.InsensitiveLike(Projections.Property<CrmContact>(c => c.Company),
            filtString))
       .Add(Restrictions.InsensitiveLike(
            Projections.SqlFunction("substring", NHibernateUtil.String,
                Projections.Property<DimServicePoint>(c => c.Phone),
                Projections.Constant(0), Projections.Constant(3)),
            filtString, MatchMode.Anywhere))
       .Add(Restrictions.InsensitiveLike(
            Projections.SqlFunction("substring", NHibernateUtil.String,
                Projections.Property<DimServicePoint>(c => c.Phone),
                Projections.Constant(3), Projections.Constant(3)),
            filtString, MatchMode.Anywhere))
       .Add(Restrictions.InsensitiveLike(
            Projections.SqlFunction("substring", NHibernateUtil.String,
                Projections.Property<DimServicePoint>(c => c.Phone),
                Projections.Constant(6), Projections.Constant(4)),
            filtString, MatchMode.Anywhere)));
