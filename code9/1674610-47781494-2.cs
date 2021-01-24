        public class MyClass
        {
            [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
            public MyEnum Value1 = MyEnum.ValueC;
            [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
            public uint Value2 = uint.MaxValue;
        }
