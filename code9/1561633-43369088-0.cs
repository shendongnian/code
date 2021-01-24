    Model1 context = new Model1();
    var product = context.Products.First();
    RelationshipManager relMgr = ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.GetRelationshipManager(product);
    IEnumerable<IRelatedEnd> relEnds = relMgr.GetAllRelatedEnds();
    IRelatedEnd relEnd = relEnds.Where(r => r.RelationshipName.EndsWith("Product_Category")).Single();
    EntityReference<Category> entityRef = relEnd as EntityReference<Category>;
    var entityKey = entityRef.EntityKey;
    int categoryId = (int)entityKey.EntityKeyValues[0].Value;
