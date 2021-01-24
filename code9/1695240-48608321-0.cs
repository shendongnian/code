    public class FooRepository : BaseRepository<Foo>
    {
       IBaseRepository<Bar> _barep;
       
      public FooRepository(IUser user, IBaseRepository<Bar> barep) : base(user)
       {
        _barep=barep;
       }
     public override int Add(Foo entity)
    {
        var d =base.Add(entity)
        //how declare BaseRepository<Bar> 
        var c = barep.Add(entity.Bar);
        return d;
    }
