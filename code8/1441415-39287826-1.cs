    WorkList workList = null;
    <your dto class name> dto = null;
    Commodity commodity = null;
    
    var subquery = QueryOver.Of(() => commodity)
        .Where(() => commodity.ProductId == workList.ID) // instead of ProductId put your foreign key property name
        .Select(Projections.SqlFunction("listProductCommodities",
            NHibernateUtil.String,
            Projections.Distinct(Projections.Property(() => commodity.Name))); //instead of name put your text field
    
    var query = Session.QueryOver(() => workList)
        .SelectList(list => list
            .Select(p => p.ID).WithAlias(() => dto.ID)
            .Select(p => p.Name).WithAlias(() => dto.Name)
            .SelectSubQuery(subquery).WithAlias(() => dto.CommodityList))
        .TransformUsing(Transformers.AliasToBean<your dto class name>())
        .List<your dto class name>();
