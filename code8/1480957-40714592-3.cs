    namespace V3
    {
        [ProtoContract]
        internal abstract class LowerStillBaseClass
        {
            [ProtoMember(1)]
            public string LowerStillBaseClassProperty { get; set; }
        }
        [ProtoContract]
        internal class MarketDataObject : LowerStillBaseClass
        {
            static MarketDataObject()
            {
                AddBaseTypeProtoMembers(RuntimeTypeModel.Default);
            }
            const int BaseTypeIncrement = 11000;
            public static void AddBaseTypeProtoMembers(RuntimeTypeModel runtimeTypeModel)
            {
                var myType = runtimeTypeModel[typeof(MarketDataObject)];
                var baseType = runtimeTypeModel[typeof(MarketDataObject).BaseType];
                if (!baseType.GetSubtypes().Any(s => s.DerivedType == myType))
                {
                    foreach (var field in baseType.GetFields())
                    {
                        myType.Add(field.FieldNumber + BaseTypeIncrement, field.Name);
                    }
                }
            }
            [ProtoMember(1)]
            public string Id { get; set; }
        }
    }
