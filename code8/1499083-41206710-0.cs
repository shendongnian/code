    //Implement these two interfaces with your classes
    public interface IClass
    {
       public int Id {get;set;}
       //other fields here.
    }
    
    public OtherClass CreateNeed(IClass inp)
     {
         var newDto = new OtherClass();
         newDto.Id = input.id;
         newDto.Name = input.name;
         newDto.NeedTypeId = input.needTypeId;
    
            return newDtoToAdd;
      }
