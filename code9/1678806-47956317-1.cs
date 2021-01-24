    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    namespace ConsoleApp15
    {
        public class TestClass
        {
            public TestClass()
            {
                _SomeField = 42;
            }
            private readonly int _SomeField;
            public ref readonly int SomeField => ref _SomeField;
        }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var propertyInfo = typeof(TestClass).GetProperty("SomeField");
                var getMethod = CreateGet<object>(propertyInfo);
                TestClass obj = new TestClass();
                var result = getMethod(obj);
            }
            public static Func<T, object> CreateGet<T>(PropertyInfo propertyInfo)
            {
                DynamicMethod dynamicMethod = CreateDynamicMethod("Get" + propertyInfo.Name, typeof(object), new[] { typeof(T) }, propertyInfo.DeclaringType);
                ILGenerator generator = dynamicMethod.GetILGenerator();
                GenerateCreateGetPropertyIL(propertyInfo, generator);
                return (Func<T, object>)dynamicMethod.CreateDelegate(typeof(Func<T, object>));
            }
            private static DynamicMethod CreateDynamicMethod(string name, Type returnType, Type[] parameterTypes, Type owner)
            {
                DynamicMethod dynamicMethod = new DynamicMethod(name, returnType, parameterTypes, owner, true);
                return dynamicMethod;
            }
            private static void GenerateCreateGetPropertyIL(PropertyInfo propertyInfo, ILGenerator generator)
            {
                MethodInfo getMethod = propertyInfo.GetGetMethod(true);
                if (getMethod == null)
                {
                    throw new ArgumentException("Property " + propertyInfo.Name + " does not have a getter.");
                }
                if (!getMethod.IsStatic)
                {
                    generator.PushInstance(propertyInfo.DeclaringType);
                }
                generator.CallMethod(getMethod);
                generator.BoxIfNeeded(propertyInfo.PropertyType);
                generator.Return();
            }
        }
        internal static class ILGeneratorExtensions
        {
            public static void PushInstance(this ILGenerator generator, Type type)
            {
                generator.Emit(OpCodes.Ldarg_0);
                if (type.IsValueType)
                {
                    generator.Emit(OpCodes.Unbox, type);
                }
                else
                {
                    generator.Emit(OpCodes.Castclass, type);
                }
            }
            public static void PushArrayInstance(this ILGenerator generator, int argsIndex, int arrayIndex)
            {
                generator.Emit(OpCodes.Ldarg, argsIndex);
                generator.Emit(OpCodes.Ldc_I4, arrayIndex);
                generator.Emit(OpCodes.Ldelem_Ref);
            }
            public static void BoxIfNeeded(this ILGenerator generator, Type type)
            {
                if (type.IsValueType)
                {
                    generator.Emit(OpCodes.Box, type);
                }
                else
                {
                    generator.Emit(OpCodes.Castclass, type);
                }
            }
            public static void UnboxIfNeeded(this ILGenerator generator, Type type)
            {
                if (type.IsValueType)
                {
                    generator.Emit(OpCodes.Unbox_Any, type);
                }
                else
                {
                    generator.Emit(OpCodes.Castclass, type);
                }
            }
            public static void CallMethod(this ILGenerator generator, MethodInfo methodInfo)
            {
                if (methodInfo.IsFinal || !methodInfo.IsVirtual)
                {
                    generator.Emit(OpCodes.Call, methodInfo);
                }
                else
                {
                    generator.Emit(OpCodes.Callvirt, methodInfo);
                }
            }
            public static void Return(this ILGenerator generator)
            {
                generator.Emit(OpCodes.Ret);
            }
        }
    }
