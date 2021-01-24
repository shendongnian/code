    public class TUnitClass
    {
        [JsonConstructor]
        TUnitClass(string id, EQuantities quantity, TypeWrapper<Enum> unit, string comment)
            : this(id, quantity, unit.Value(), comment)
        {
        }
        public TUnitClass(string id, EQuantities quantity, Enum unit, string comment)
        {
            Id = id;
            Name = quantity.ToString();
            Quantity = quantity;
            Unit = unit;
            Comment = comment;
            FieldInfo fi = unit.GetType().GetField(unit.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            displayingString = attributes[0].Description;
        }
        public string Id { set; get; }
        public string Name { set; get; }
        public EQuantities Quantity { set; get; }
        [JsonIgnore]
        public System.Enum Unit { get; set; }
        [JsonProperty("Unit", TypeNameHandling = TypeNameHandling.All)]
        TypeWrapper<Enum> UnitSurrogate
        {
            get
            {
                return Unit == null ? null : TypeWrapper<Enum>.CreateWrapper(Unit);
            }
            set
            {
                Unit = value.Value();
            }
        }
        public string Comment { set; get; }
        public string displayingString { set; get; }
        public TUnitClass Copy()
        {
            TUnitClass copiedUnitClass=new TUnitClass(Id,Quantity,Unit,Comment);
            return copiedUnitClass;
        }
    }
    public abstract class TypeWrapper<TBase>
    {
        protected TypeWrapper() { }
        [JsonIgnore]
        public abstract TBase BaseValue { get; }
        public static TypeWrapper<TBase> CreateWrapper<TDerived>(TDerived value) where TDerived : TBase
        {
            if (value == null)
                return null;
            var type = value.GetType();
            if (type == typeof(TDerived))
                return new TypeWrapper<TDerived, TBase>(value);
            // Return actual type of subclass
            return (TypeWrapper<TBase>)Activator.CreateInstance(typeof(TypeWrapper<,>).MakeGenericType(type, typeof(TBase)), value);
        }
    }
    public static class TypeWrapperExtensions
    {
        public static TBase Value<TBase>(this TypeWrapper<TBase> wrapper)
        {
            if (wrapper == null || wrapper.BaseValue == null)
                return default(TBase);
            return wrapper.BaseValue;
        }
    }
    public sealed class TypeWrapper<TDerived, TBase> : TypeWrapper<TBase> where TDerived : TBase
    {
        public TypeWrapper() : base() { }
        public TypeWrapper(TDerived value)
            : base()
        {
            this.Value = value;
        }
        public override TBase BaseValue { get { return Value; } }
        public TDerived Value { get; set; }
    }
