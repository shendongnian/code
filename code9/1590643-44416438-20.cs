    public class FooAdapter : IFooDTO
    {
       FooEntity entity;
       FooAdapter(FooEntity entity)
       {
          this.entity = entity;
       }
      
       public int Id 
       {
          get {return this.entity.Id;}
          set {/*Do nothing set by EF*/}
       }
       public string Name
       {
           get {return this.entity.Name;}
           set {this.entity.Name = value; }
       }
       public void Apply(FooDTO foo)
       {
            //I don't remember if this is the correct order but you get the gyst
            this._mapper.Map<IFooDTO, IFooDTO>(this, foo);
       }
    }
   
