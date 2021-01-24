    public static class MyObjectDtoMapper {
        public static MyDto Map(MyObject obj) {
            return new MyDto {
                OnlyPropertyWanted = obj.Property
            };
        }
    }
    var dtoMappedObject = MyObjectJsonDtoMapper.Map(object);
    return Json.Convert(dtoMappedObject);
