    var left = Projections.SqlFunction("COALESCE",
    NHibernateUtil.String,
    Projections.Property<Stack>(pc => pc.OldestChildeName),
    Projections.Constant(""));
    
    
    var right = Projections.SqlFunction("COALESCE",
    NHibernateUtil.String,
    Projections.Property<Stack>(pc => pc.WifeName),
    Projections.Constant("") );
    
    var restriction = Restrictions.EqProperty(left, right);
    
    var dd = contex.Session<Stack>().QueryOver<Stack>().Where(restriction).List();
