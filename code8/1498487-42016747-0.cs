    #if WINDOWS_APP || WINDOWS_PHONE_APP
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MethodInfos = System.Collections.Generic.IEnumerable<System.Reflection.MethodInfo>;
    namespace System.Reflection
    {
        public static class CustomExtensions
        {
            public static Assembly Assembly(this Type T) { return T.GetTypeInfo().Assembly; }
            public static MethodInfos GetDeclaredMethods(this Type T) { return T.GetTypeInfo().DeclaredMethods; }
            public static MethodInfo GetDeclaredMethod(this Type T, string name) { return T.GetTypeInfo().GetDeclaredMethod(name); }
            public static bool IsInstanceOfType(this Type T, object o)
            {
                if (o == null)
                    return false;
    
                // No need for transparent proxy casting check here
                // because it never returns true for a non-rutnime type.
    
                return T.GetTypeInfo().IsAssignableFrom(o.GetType().GetTypeInfo());
            }
            public static bool IsAssignableFrom(this Type T1, Type T2)
            { return T1.GetTypeInfo().IsAssignableFrom(T2.GetType().GetTypeInfo()); }
            public static bool IsEnum(this Type type)
            {
                return type.GetTypeInfo().IsEnum;
            }
    
            public static bool IsGenericType(this Type type)
            {
                return type.GetTypeInfo().IsGenericType;
            }
    
            public static bool IsValueType(this Type type)
            {
                return type.GetTypeInfo().IsValueType;
            }
    
            public static bool HasAttribute<T>(this ParameterInfo member) where T : Attribute
            {
                return member.GetCustomAttributes<T>().Any();
            }
    
            public static Type[] GetGenericArguments(this Type T)
            { return T.GetTypeInfo().GenericTypeArguments; }
            public static MethodInfo GetMethod(this Type T, string Name)
            { return T.GetTypeInfo().GetDeclaredMethod(Name); }
            public static MethodInfo GetMethod(this Type T, string Name, Type[] Types)
            {
                var Params = T.GetTypeInfo().GetDeclaredMethods(Name);
                foreach (var Item in Params)
                {
                    bool Yes = false;
                    for (int i = 0; i < Types.Count(); i++)
                        Yes |= Types[i] == Item.GetParameters()[i].ParameterType;
                    if (Yes) return Item;
                }
                return null;
            }
            public static IEnumerable<Type> GetNestedTypes(this Type T)
            { foreach (TypeInfo Info in T.GetTypeInfo().DeclaredNestedTypes)
                    yield return Info.AsType();
            }
            public static IEnumerable<Type> GetNestedTypes(this Type T, BindingFlags Flags)
            {
                foreach (TypeInfo Info in T.GetTypeInfo().DeclaredNestedTypes)
                    if(Filter(T.GetTypeInfo(), Flags)) yield return Info.AsType();
            }
            private static bool Filter(TypeInfo Info, BindingFlags Flags)
            {
                bool Return = false;
                if (Flags.HasFlag(BindingFlags.DeclaredOnly)) Return |= Info.IsNested;
                if (Flags.HasFlag(BindingFlags.Instance)) Return |= !(Info.IsAbstract | Info.IsSealed);
                if (Flags.HasFlag(BindingFlags.Static)) Return |= Info.IsAbstract | Info.IsSealed;
                if (Flags.HasFlag(BindingFlags.Public)) Return |= Info.IsPublic;
                if (Flags.HasFlag(BindingFlags.NonPublic)) Return |= Info.IsNotPublic;
                return Return;
            }
            private static bool Filter(MethodInfo Info, BindingFlags Flags)
            {
                bool Return = false;
                if (Flags.HasFlag(BindingFlags.DeclaredOnly)) Return |= Info.IsFamily;
                if (Flags.HasFlag(BindingFlags.Instance)) Return |= !Info.IsStatic;
                if (Flags.HasFlag(BindingFlags.Static)) Return |= Info.IsStatic;
                if (Flags.HasFlag(BindingFlags.Public)) Return |= Info.IsPublic;
                if (Flags.HasFlag(BindingFlags.NonPublic)) Return |= !Info.IsPublic;
                return Return;
            }
            public static IEnumerable<Type> GetTypes(this Assembly A)
            { return A.ExportedTypes; }
        }
        /// <summary>Specifies flags that control binding and the way in which the search for members and types is conducted by reflection.</summary>
        [Flags, Runtime.InteropServices.ComVisible(true)]
        public enum BindingFlags
        {
            /// <summary>Specifies no binding flag.</summary>
            Default = 0,
            /// <summary>Specifies that the case of the member name should not be considered when binding.</summary>
            //IgnoreCase = 1,
            /// <summary>Specifies that only members declared at the level of the supplied type's hierarchy should be considered. Inherited members are not considered.</summary>
            DeclaredOnly = 2,
            /// <summary>Specifies that instance members are to be included in the search.</summary>
            Instance = 4,
            /// <summary>Specifies that static members are to be included in the search.</summary>
            Static = 8,
            /// <summary>Specifies that public members are to be included in the search.</summary>
            Public = 16,
            /// <summary>Specifies that non-public members are to be included in the search.</summary>
            NonPublic = 32,
            /*
            /// <summary>Specifies that public and protected static members up the hierarchy should be returned. Private static members in inherited classes are not returned. Static members include fields, methods, events, and properties. Nested types are not returned.</summary>
            FlattenHierarchy = 64,
            /// <summary>Specifies that a method is to be invoked. This must not be a constructor or a type initializer.</summary>
            InvokeMethod = 256,
            /// <summary>Specifies that Reflection should create an instance of the specified type. Calls the constructor that matches the given arguments. The supplied member name is ignored. If the type of lookup is not specified, (Instance | Public) will apply. It is not possible to call a type initializer.</summary>
            CreateInstance = 512,
            /// <summary>Specifies that the value of the specified field should be returned.</summary>
            GetField = 1024,
            /// <summary>Specifies that the value of the specified field should be set.</summary>
            SetField = 2048,
            /// <summary>Specifies that the value of the specified property should be returned.</summary>
            GetProperty = 4096,
            /// <summary>Specifies that the value of the specified property should be set. For COM properties, specifying this binding flag is equivalent to specifying PutDispProperty and PutRefDispProperty.</summary>
            SetProperty = 8192,
            /// <summary>Specifies that the PROPPUT member on a COM object should be invoked. PROPPUT specifies a property-setting function that uses a value. Use PutDispProperty if a property has both PROPPUT and PROPPUTREF and you need to distinguish which one is called.</summary>
            PutDispProperty = 16384,
            /// <summary>Specifies that the PROPPUTREF member on a COM object should be invoked. PROPPUTREF specifies a property-setting function that uses a reference instead of a value. Use PutRefDispProperty if a property has both PROPPUT and PROPPUTREF and you need to distinguish which one is called.</summary>
            PutRefDispProperty = 32768,
            /// <summary>Specifies that types of the supplied arguments must exactly match the types of the corresponding formal parameters. Reflection throws an exception if the caller supplies a non-null Binder object, since that implies that the caller is supplying BindToXXX implementations that will pick the appropriate method.</summary>
            ExactBinding = 65536,
            /// <summary>Not implemented.</summary>
            SuppressChangeType = 131072,
            /// <summary>Returns the set of members whose parameter count matches the number of supplied arguments. This binding flag is used for methods with parameters that have default values and methods with variable arguments (varargs). This flag should only be used with <see cref="M:System.Type.InvokeMember(System.String,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object,System.Object[],System.Reflection.ParameterModifier[],System.Globalization.CultureInfo,System.String[])" />.</summary>
            OptionalParamBinding = 262144,
            /// <summary>Used in COM interop to specify that the return value of the member can be ignored.</summary>
            IgnoreReturn = 16777216
            */
        }
    }
    #endif
