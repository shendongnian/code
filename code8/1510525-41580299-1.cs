    /// <summary>
    /// Dynamic property builder, with value assigned.
    /// </summary>
    public class DynamicPropertyValue
    {
        object value;
        string name;
        Type type;
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">The name of the property.</param>
        /// <param name="type">The type of the property</param>
        /// <param name="value">The value of the property.</param>
        public DynamicPropertyValue(string name, Type type, object value)
        {
            if (name == null) throw new ArgumentNullException("name");
            if (type == null) throw new ArgumentNullException("type");
            if (value == null) throw new ArgumentNullException("value");
            this.name = name;
            this.type = type;
            this.value = value;
        }
        /// <summary>
        /// Gets, the property name.
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Gets, the property type.
        /// </summary>
        public Type Type
        {
            get { return type; }
        }
        /// <summary>
        /// Gets, the property value.
        /// </summary>
        public object Value
        {
            get { return value; }
        }
    }
