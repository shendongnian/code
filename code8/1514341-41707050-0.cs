        var dictr = new UnityContainer();
        dictr.RegisterType<IPersonFactory, PersonFactory>();
        dictr.RegisterType<IVisitSite, SiteVisit>();
        var personFactory = dictr.Resolve<IPersonFactory>();
        IPerson person = personFactory.CreatePrincipal(your args here); 
        var siteVisit = dictr.Resolve<IVisitSite>();
        siteVisit.Visit(person);
