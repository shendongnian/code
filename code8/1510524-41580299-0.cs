    private AssemblyName _assemblyName;
    private AssemblyBuilder _asssemblyBuilder;
    private ModuleBuilder _moduleBuilder;
    private Dictionary<SignatureBuilder, Type> _classes;
    private ReaderWriterLock _rwLock;
    private TypeBuilder _typeBuilder;
    private string _typeName;
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="moduleName">The name of the assembly module.</param>
        public DynamicTypeBuilder(string moduleName)
        {
            // Make sure the page reference exists.
            if (moduleName == null) throw new ArgumentNullException("moduleName");
            // Create the nw assembly
            _assemblyName = new AssemblyName(moduleName);
            _asssemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(_assemblyName, AssemblyBuilderAccess.Run);
            // Create only one module, therefor the
            // modile name is the assembly name.
            _moduleBuilder = _asssemblyBuilder.DefineDynamicModule(_assemblyName.Name);
            // Get the class unique signature.
            _classes = new Dictionary<SignatureBuilder, Type>();
            _rwLock = new ReaderWriterLock();
        }
