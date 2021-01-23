    var links = session.Query<ProductLinkProducer>().ToList(); 
    links.ForEach(x => session.Evict(x));
    foreach (var link in links)
    {
    	link.Product = syncSession.Get<Product>(link.Product.Id);
    	link.Producer = syncSession.Get<Producer>(link.Producer.Id);
    	syncSession.Save(link);
    }
    syncSession.Flush();
