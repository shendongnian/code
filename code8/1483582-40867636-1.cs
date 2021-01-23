        public override Cylinder Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();
            Cylinder a = new Cylinder {Id = context.Reader.ReadObjectId()};
            context.Reader.ReadStartDocument();
            a.description.type = context.Reader.ReadString();
            a.description.kind = context.Reader.ReadString();
            a.description.year = (short)context.Reader.ReadInt32();
            a.description.producer = context.Reader.ReadString();
            context.Reader.ReadStartArray();
            a.description.brands = new List<string>();
            while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                a.description.brands.Add(context.Reader.ReadString());
            }
            context.Reader.ReadEndArray();
            context.Reader.ReadStartArray();
            a.description.model = new Cylinder.mode(new List<string>());
            while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                a.description.model.items.Add(context.Reader.ReadString());
            }
            context.Reader.ReadEndArray();
            a.description.internalproducerdesignation = context.Reader.ReadString();
            a.description.origin = context.Reader.ReadString();
            context.Reader.ReadEndDocument();
            context.Reader.ReadStartDocument();
            a.elements = new Cylinder.elem
            {
                nonspringelements = (short) context.Reader.ReadInt32(),
                springelements = (short) context.Reader.ReadInt32(),
                discelements = (short) context.Reader.ReadInt32(),
                magneticelements = (short) context.Reader.ReadInt32(),
                activeelements = (short) context.Reader.ReadInt32(),
                passiveelements = (short) context.Reader.ReadInt32(),
                totalelements = (short) context.Reader.ReadInt32()
            };
            context.Reader.ReadEndDocument();
            a.profiles =  readStringArray(context);
            a.certifications = readStringArray(context);
            a.colors = readStringArray(context);
            a.specialfittings = readStringArray(context);
            a.cutdepths = (short) context.Reader.ReadInt32();
            a.rareness = context.Reader.ReadString();
            context.Reader.ReadStartDocument();
            a.value = new Cylinder.val
            {
                @new = context.Reader.ReadString(),
                used = context.Reader.ReadString()
            };
            context.Reader.ReadEndDocument();
            context.Reader.ReadStartDocument();
            var blawInt = context.Reader.ReadDouble();
            var blawBool = context.Reader.ReadBoolean();
            context.Reader.ReadEndDocument();
            a.availableat = context.Reader.ReadString();
            a.specialabout = context.Reader.ReadString();
            context.Reader.ReadStartDocument();
            a.development = new Cylinder.devel
            {
                predecessor = context.Reader.ReadString(),
                follower = context.Reader.ReadString()
            };
            context.Reader.ReadEndDocument();
            var objects=new List<object>();
            context.Reader.ReadStartArray();
            while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                objects.Add(context.Reader.ReadString());
            }
            context.Reader.ReadEndArray();
            a.media = objects.ToArray();
            context.Reader.ReadEndDocument();
            return a;
        }
        private static IEnumerable<string> readStringArray(BsonDeserializationContext context)
        {
            context.Reader.ReadStartArray();
            var strings = new List<string>();
            while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                strings.Add(context.Reader.ReadString());
            }
            context.Reader.ReadEndArray();
            return strings;
        }
