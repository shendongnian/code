    Mapper.CreateMap<B, A>();
    Mapper.CreateMap<C, A>();
    Mapper.CreateMap<B, IEnumerable<A>>().ConvertUsing<BConverter>();
    
    class BConverter : ITypeConverter<B, IEnumerable<A>> {
        public IEnumerable<A> Convert(ResulutionContext ctx) {
            B b = (B)ctx.SourceValue;
            foreach(var aFromC in b.AttrBList.Select(c => Mapper.Map<A>(c))) { // map c attributes into an a object and return it (through Select it's a mapping for all items of the list AttrBList)
                Mapper.Map(b, aFromC); // push the attribute values from b to the aFromC object. Because this is inside the loop, it happens for every Item in the AttrBList array
                yield return aFromC;
            }
        }
    }
