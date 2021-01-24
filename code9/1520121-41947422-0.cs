    public class TUnitClass
    {
        [JsonConstructor]
        TUnitClass(string id, EQuantities quantity, TypeWrapper unit, string comment)
            : this(id, quantity, unit.Value<Enum>(), comment)
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
        TypeWrapper UnitValue
        {
            get
            {
                return Unit == null ? null : TypeWrapper.CreateWrapper(Unit);
            }
            set
            {
                Unit = value.Value<Enum>();
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
    public abstract class TypeWrapper
    {
        protected TypeWrapper() { }
        [JsonIgnore]
        public abstract object ObjectValue { get; }
        public static TypeWrapper CreateWrapper<T>(T value)
        {
            if (value == null)
                return new TypeWrapper<T>();
            var type = value.GetType();
            if (type == typeof(T))
                return new TypeWrapper<T>(value);
            // Return actual type of subclass
            return (TypeWrapper)Activator.CreateInstance(typeof(TypeWrapper<>).MakeGenericType(type), value);
        }
    }
    public static class TypeWrapperExtensions
    {
        public static T Value<T>(this TypeWrapper wrapper)
        {
            if (wrapper == null || wrapper.ObjectValue == null)
                return default(T);
            return (T)wrapper.ObjectValue;
        }
    }
    public sealed class TypeWrapper<T> : TypeWrapper
    {
        public TypeWrapper() : base() { }
        public TypeWrapper(T value)
            : base()
        {
            this.Value = value;
        }
        public override object ObjectValue { get { return Value; } }
        public T Value { get; set; }
    }
