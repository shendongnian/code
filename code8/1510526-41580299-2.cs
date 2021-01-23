    /// <summary>
    /// Dynamic method builder.
    /// </summary>
    public class DynamicMethod
    {
        string name;
        IEnumerable<Type> parameters;
        Type returnType;
        Action<TypeBuilder> buildAction = null;
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">The name of the method.</param>
        /// <param name="parameters">The collection parameter types.</param>
        /// <param name="returnType">The return type.</param>
        public DynamicMethod(string name, IEnumerable<Type> parameters, Type returnType)
        {
            if (name == null) throw new ArgumentNullException("name");
            this.name = name;
            this.parameters = parameters;
            this.returnType = returnType;
        }
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="name">The name of the method.</param>
        /// <param name="parameters">The collection parameter types.</param>
        /// <param name="returnType">The return type.</param>
        /// <param name="buildAction">The build action.</param>
        public DynamicMethod(string name, IEnumerable<Type> parameters, Type returnType, Action<TypeBuilder> buildAction)
        {
            if (name == null) throw new ArgumentNullException("name");
            this.name = name;
            this.parameters = parameters;
            this.returnType = returnType;
            this.buildAction = buildAction;
        }
        /// <summary>
        /// Gets, the method name.
        /// </summary>
        public string Name
        {
            get { return name; }
        }
        /// <summary>
        /// Gets, the collection of parameters
        /// </summary>
        public IEnumerable<Type> Parameters
        {
            get { return parameters; }
        }
        /// <summary>
        /// Gets, the return type.
        /// </summary>
        public Type ReturnType
        {
            get { return returnType; }
        }
        /// <summary>
        /// Gets, build action.
        /// </summary>
        public Action<TypeBuilder> BuildAction
        {
            get { return buildAction; }
        }
    }
