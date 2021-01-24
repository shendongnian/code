    public class InheritanceTest
    {
        static void Main()
        {
            Console.WriteLine(CreateProto());
    
            var obj = new SubClass {
                StringPropOnBaseClass = "abc",
                StringPropOnSubClass = "def" };
            var clone = Serializer.DeepClone(obj);
            Console.WriteLine(clone.StringPropOnBaseClass);
            Console.WriteLine(clone.StringPropOnSubClass);
        }
        public static string CreateProto()
        {
            var model = ProtoBuf.Meta.RuntimeTypeModel.Default;
    
            var metaType = model.Add(typeof(SubClass), false);
            metaType.AddField(1, "StringPropOnSubClass");
            metaType.AddField(2, "StringPropOnBaseClass");
    
            var schema =model.GetSchema(typeof(SubClass), ProtoSyntax.Proto3);
            return schema;
        }
    }
