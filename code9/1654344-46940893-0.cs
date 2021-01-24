    public class MyEntityMap: ClassMap<MyEntity>
    {
        public MyEntityMap()
        {
            UseCompositeId()
              .WithKeyProperty(x => x.Id1)
              .WithReferenceProperty(x => x.Id2);
        }
    }
