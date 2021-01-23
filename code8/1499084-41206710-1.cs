    public OtherClass CreateNeed<T>(T inp) where T: IClass 
         {
             var newDto = new OtherClass();
             newDto.Id = inp.id;
             newDto.Name = inp.name;
             newDto.NeedTypeId = inp.needTypeId;        
             return newDtoToAdd;
          }
