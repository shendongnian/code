        public class AttributeValue
        {
            public virtual int Id { get; set; }
    
            public virtual int CharacterId { get; set; }
    
            public virtual int AttributeId { get; set; }
    
            public virtual string Text { get; set; }
    
            public virtual decimal? Number { get; set; }
    
            public virtual bool? Flag { get; set; }
    
            public virtual DateTime? Date { get; set; }
    
            public virtual Attribute Attribute { get; set; }
    
            public virtual Character Character { get; set; }
    
            public dynamic GetValue() 
            {
                switch (Attribute.DataType)
                {
                    case Attribute.ValueTypes.Text:
                        return Text;
                    case Attribute.ValueTypes.DateTime:
                        return Date ?? DateTime.MinValue;
                    case Attribute.ValueTypes.Decimal:
                        return Number ?? 0M;
                    case Attribute.ValueTypes.Boolean:
                        return Flag ?? false;
                    default:
                        return null;
                }
            }
    
            public T? GetValue<T>() where T : struct
            {
                switch (typeof(T).Name)
                {
                    case "String":
                        return (T)Convert.ChangeType(Text, typeof(T));
                    case "Decimal":
                        return (T)Convert.ChangeType(Number ?? 0M, typeof(T));
                    case "Boolean":
                        return (T)Convert.ChangeType(Flag ?? false, typeof(T));
                    case "DateTime":
                        return (T)Convert.ChangeType(Date ?? DateTime.MinValue, typeof(T));
                }
    
                throw  new InvalidOperationException();
            }
    
        }
