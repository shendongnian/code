        // Defaults to int.
        public enum MyEnum
        {
            ValueA = 1233104067,
            ValueB = 1119849093,
            ValueC = unchecked((int)2726580491)
        }
        // Usage.
        uint a = (uint)MyEnum.ValueA;
        uint b = (uint)MyEnum.ValueB;
        uint c = unchecked((uint)MyEnum.ValueC);
        uint d = (uint)document["MyProperty"].AsInt32; // Reading from a BsonDocument.
