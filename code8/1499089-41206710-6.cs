    //Implement this interface with your 2 classes
    public interface IClass
    {
       public int Id {get;set;}
       //other fields here.
    }
    public interface OtherClass : IClass
    {
       public int Id {get;set;}
       //other fields here.
    }
    public interface NeedClass : IClass
    {
       public int Id {get;set;}
       //other fields here.
    }
    
    public OtherClass CreateNeed(IClass input)
     {
         var newDto = new OtherClass();
         newDto.Id = input.id;
         newDto.Name = input.name;
         newDto.NeedTypeId = input.needTypeId;    
         return newDtoToAdd;
      } 
      //example call 
      var newNeedClass = new NeedClass();
      //set all your properties here.
      newNeedClass.Id =1;
      var otherClassInstance = CreateNeed(newNeedClass );
