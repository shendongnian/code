    If using driver v2.4.3 or earlier:
        public class MyClass
        {
            [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
            public MyEnum Value1 = MyEnum.ValueC;
            [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
            public uint Value2 = uint.MaxValue;
        }
    Unfortunately the serializer in driver v2.4.4 and later doesn't respect 
    <code>AllowOverflow</code>, throwing an exception anyway(tested and 
    confirmed, thanks to dnickless for pointing this out). Here's a workaround 
    (at the expense of some wasted space):
        public class MyClass
        {
            [BsonRepresentation(BsonType.Int64)]
            public MyEnum Value1 = MyEnum.ValueC;
            [BsonRepresentation(BsonType.Int64)]
            public uint Value2 = uint.MaxValue;
        }
