    public class ExpressionMap : ClassMap<Expression>
    {   
        public ExpressionMap()
        {
            Table("Expressions");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ExpressionId");
            Map(x => x.Name).Column("Name").Not.Nullable();
            Map(x => x.Script);
            Map(x => x.Language);
            HasMany(x => x.Topologies);
        }
    }
