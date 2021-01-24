    public class MyContentModel: APIModel
    {
        public string Property {get; set;}
        public override string TypeName()
        {
            return "JsonKey";
        }
    }
