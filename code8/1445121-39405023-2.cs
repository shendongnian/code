    public class EFQueryable<TEntity> : IQueryable<TEntity>
    {
        . . .
    }
    public SomeContext
    {
        public EFQueryable<SomeModel1> SomeModels1 { get; set; }
        public EFQueryable<SomeModel2> SomeModels2 { get; set; }
    }
    someVar = SomeContext.SomeModel1s.Where(x => x.SomeID == externalID).OrderBy(x => x.SomeProperty).ToList();
