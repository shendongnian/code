    public class Step1Document
    {
        public List<Step1Element> Collection { get; set; }
        public Document Upcast()
        {
            return new Document
            {
                Collection = Collection.Select(m => m.Upcast()).ToList()
            };
        }
    }
    public class Step1Element
    {
        // Fields from TypeA and TypeB
        public string Type { get; set; }
        public string TypeAProperty { get; set; }
        public string TypeBProperty { get; set; }
        internal IBaseObject Upcast()
        {
            if(Type == "TypeA")
            {
                return new TypeAClass
                {
                    Type = Type,
                    TypeAProperty = TypeAProperty
                };
            }
            if (Type == "TypeB")
            {
                return new TypeBClass
                {
                    Type = Type,
                    TypeBProperty = TypeBProperty
                };
            }
            throw new NotImplementedException(Type);
        }
    }
