        public override Cylinder Deserialize(MongoDB.Bson.Serialization.BsonDeserializationContext context, MongoDB.Bson.Serialization.BsonDeserializationArgs args)
        {
            context.Reader.ReadStartDocument();
            Cylinder a = new Cylinder();
            a.Id = context.Reader.ReadObjectId();
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
            a.description.model=new Cylinder.mode(new List<string>());
            while (context.Reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                a.description.model.items.Add(context.Reader.ReadString());
            }
            context.Reader.ReadEndArray();
            a.description.internalproducerdesignation = context.Reader.ReadString();
            a.description.origin = context.Reader.ReadString();
            context.Reader.ReadEndDocument();
            return a;
        }
