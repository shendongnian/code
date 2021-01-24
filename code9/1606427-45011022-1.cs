    public static class MyObjectDtoMapper {
        public static Contract.MyDto Map(SpecificDomain.MyObject obj) {
            return new MyDto {
                OnlyPropertyWanted = obj.Property
            };
        }
    }
    var dtoMappedObject = MyObjectJsonDtoMapper.Map(object);
    return JsonConvert.SerializeObject(dtoMappedObject);
