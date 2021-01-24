    public class Enhancer
    {
        private static readonly ModuleBuilder ModuleBuilder;
        static Enhancer()
        {
            var b = AssemblyBuilder.DefineDynamicAssembly(
                new AssemblyName(Guid.NewGuid().ToString()),
                AssemblyBuilderAccess.Run);
            ModuleBuilder = b.DefineDynamicModule($"{b.GetName().Name}.Module");
        }
        
        private const BindingFlags InstanceFlags = BindingFlags.Instance |
                                                   BindingFlags.Public |
                                                   BindingFlags.NonPublic;
        private const FieldAttributes CacheFlags = FieldAttributes.Private |
                                                   FieldAttributes.Static |
                                                   FieldAttributes.InitOnly;
        private const TypeAttributes TypeFlags = TypeAttributes.Public |
                                                 TypeAttributes.Sealed |
                                                 TypeAttributes.BeforeFieldInit |
                                                 TypeAttributes.AutoLayout |
                                                 TypeAttributes.AnsiClass;
        
        private static IEnumerable<(PropertyInfo p, EnhancedAttribute[] a)> FindEnhancedProperties(Type t)
        {
            foreach (var p in t.GetProperties(InstanceFlags))
            {
                if (p.CanWrite && p.GetSetMethod(true).IsVirtual && p.IsDefined(typeof(EnhancedAttribute)))
                    yield return (p, FindEnhancedAttributes(p));
            }
        }
        public static EnhancedAttribute[] FindEnhancedAttributes(PropertyInfo p)
        {
            return p.GetCustomAttributes<EnhancedAttribute>().ToArray();
        }
        private static readonly MethodInfo CheckMethod =
            typeof(EnhancedAttribute).GetMethod(
                nameof(EnhancedAttribute.Check),
                new[] { typeof(object[]) });
        private static readonly MethodInfo GetTypeFromHandleMethod =
            typeof(Type).GetMethod(
                nameof(Type.GetTypeFromHandle),
                new[] { typeof(RuntimeTypeHandle) });
        private static readonly MethodInfo GetPropertyMethod =
            typeof(Type).GetMethod(
                nameof(Type.GetProperty),
                new[] { typeof(string), typeof(BindingFlags) });
        private static readonly MethodInfo FindEnhancedAttributesMethod =
            typeof(Enhancer).GetMethod(
                nameof(FindEnhancedAttributes),
                new[] { typeof(PropertyInfo) });
        
        private readonly Type _base;
        private readonly TypeBuilder _enhanced;
        private readonly (PropertyInfo p, EnhancedAttribute[] attributes)[] _properties;
        private readonly FieldBuilder[] _attributeCaches;
        private readonly MethodBuilder[] _propertySetters;
        private static readonly Dictionary<Type, Type> Cache = new Dictionary<Type, Type>();
        public static T Build<T>(params object[] args) where T : class
        {
            lock (Cache)
            {
                if (!Cache.TryGetValue(typeof(T), out var type))
                    Cache[typeof(T)] = type = new Enhancer(typeof(T)).Enhance();
                return (T)Activator.CreateInstance(type, args);
            }
        }
        private Enhancer(Type t)
        {
            if (t?.IsSealed != false || t.IsInterface)
            {
                throw new ArgumentException(
                    "Type must be a non-sealed, non-abstract class type.");
            }
            _base = t;
            _enhanced = ModuleBuilder.DefineType($"<Enhanced>{t.FullName}", TypeFlags, t);
            _properties = FindEnhancedProperties(t).ToArray();
            _attributeCaches = _properties.Select(
                p => _enhanced.DefineField(
                    $"__{p.p.Name}Attributes",
                    typeof(EnhancedAttribute[]),
                    CacheFlags)).ToArray();
            
            _propertySetters = new MethodBuilder[_properties.Length];
        }
        private Type Enhance()
        {
            GenerateTypeInitializer();
            for (int i = 0, n = _properties.Length; i < n; i++)
                EnhanceProperty(i);
            GenerateConstructors();
            
            return _enhanced.CreateType();
        }
        private void GenerateConstructors()
        {
            var baseCtors = _base.GetConstructors(InstanceFlags);
            foreach (var baseCtor in baseCtors)
            {
                if (baseCtor.IsPrivate)
                    continue;
                var parameters = baseCtor.GetParameters();
                
                var ctor = _enhanced.DefineConstructor(
                    baseCtor.Attributes,
                    baseCtor.CallingConvention,
                    parameters.Select(p => p.ParameterType).ToArray());
                var il = ctor.GetILGenerator();
                
                il.Emit(OpCodes.Ldarg_0);
                for (int i = 0; i < parameters.Length; i++)
                    il.Emit(OpCodes.Ldarg, i + 1);
                
                il.Emit(OpCodes.Call, baseCtor);
                il.Emit(OpCodes.Ret);
            }
        }
        private void GenerateTypeInitializer()
        {
            var typeInit = _enhanced.DefineTypeInitializer();
            var il = typeInit.GetILGenerator();
            for (int i = 0, n = _properties.Length; i < n; i++)
            {
                var p = _properties[i];
                il.Emit(OpCodes.Ldtoken, _base);
                il.EmitCall(OpCodes.Call, GetTypeFromHandleMethod, null);
                il.Emit(OpCodes.Ldstr, p.p.Name);   
                il.Emit(OpCodes.Ldc_I4_S, (int)InstanceFlags);
                il.EmitCall(OpCodes.Call, GetPropertyMethod, null);
                il.EmitCall(OpCodes.Call, FindEnhancedAttributesMethod, null);
                il.Emit(OpCodes.Stsfld, _attributeCaches[i]);
            }
            
            il.Emit(OpCodes.Ret);
        }
        private void EnhanceProperty(int index)
        {
            var p = _properties[index];
            
            var property = _enhanced.DefineProperty(
                p.p.Name,
                p.p.Attributes,
                p.p.PropertyType,
                null);
            var baseSet = p.p.GetSetMethod(true);
            var set = _enhanced.DefineMethod(
                baseSet.Name,
                baseSet.Attributes & ~MethodAttributes.NewSlot | MethodAttributes.Final,
                baseSet.CallingConvention,
                baseSet.ReturnType,
                new[] { p.p.PropertyType });
            property.SetSetMethod(set);
            _enhanced.DefineMethodOverride(set, baseSet);
            var il = set.GetILGenerator();
            for (int j = 0, n = p.attributes.Length; j < n; j++)
            {
                il.Emit(OpCodes.Ldsfld, _attributeCaches[index]);
                il.Emit(OpCodes.Ldc_I4, j);
                il.Emit(OpCodes.Ldelem_Ref, j);
                il.Emit(OpCodes.Ldc_I4_1);
                il.Emit(OpCodes.Newarr, typeof(object));
                il.Emit(OpCodes.Dup);
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Ldarg_1);
                
                if (p.p.PropertyType.IsValueType)
                    il.Emit(OpCodes.Box, p.p.PropertyType);
                
                il.Emit(OpCodes.Stelem_Ref);
                il.EmitCall(OpCodes.Callvirt, CheckMethod, null);
            }
            
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.EmitCall(OpCodes.Call, baseSet, null);
            il.Emit(OpCodes.Ret);
            
            _propertySetters[index] = set;
        }
    }
