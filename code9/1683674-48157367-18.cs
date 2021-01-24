        [DataContract]
        public class Test
        {
            [DataMember]
            int A;
            [DataMember]
            int b;
            public Test(int _a, int _b)
            {
                A = _a;
                b = _b;
            }
        };
    Note that data contract serialization is opt-in so you will need to mark *every* member to be serialized with `[DataMember]`.  Kind of a nuisance but useful if you don't want your c# models to have a dependency on Json.NET.
    This also works for nonpublic properties.
