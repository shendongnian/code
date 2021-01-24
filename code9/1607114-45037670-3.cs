    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    namespace Test
    {
        public class Program
        {
            public static void Main()
            {
                var parent = new Parent<Class>();
                // OK: TProperty == int. Prints "1"
                parent.Map(c => c.IntValue);
                // OK: TProperty == int. Prints "2"
                parent.Map(c => c.IEnumerableIntValue);
                // Wrong: TProperty == ICollection<int>. Prints "1"
                parent.Map(c => c.ICollectionIntValue);
                // Wrong: TProperty == List<int>. Prints "1"
                parent.Map(c => c.ListIntValue);
                // Wrong: TProperty == int[]. Prints "1"
                parent.Map(c => c.ArrayIntValue);
            }
            public class Class
            {
                public int IntValue { get; set; }
                public IEnumerable<int> IEnumerableIntValue { get; set; }
                public ICollection<int> ICollectionIntValue { get; set; }
                public List<int> ListIntValue { get; set; }
                public int[] ArrayIntValue { get; set; }
            }
        }
        public class Parent<T>
        {
            public void Map<TProperty>(Expression<Func<T, TProperty>> expression)
            {
                if (ReflectionHelpers.IsUnambiguousIEnumerableOfT(typeof(TProperty)))
                {
                    MapMany(expression);
                }
                else
                {
                    MapOne(expression);
                }
            }
            void MapOne(Expression expression)
            {
                Console.WriteLine("1");
            }
            void MapMany(Expression expression)
            {
                Console.WriteLine("2");
            }
        }
        static class ReflectionHelpers
        {
            public static bool IsUnambiguousIEnumerableOfT(Type type)
            {
                // Simple case - the type *is* IEnumerable<T>.
                if (IsIEnumerableOfT(type)) {
                    return true;
                }
                // Harder - the type *implements* IEnumerable<T>.
                HashSet<Type> distinctIEnumerableImplementations = new HashSet<Type>();
                ExtractAllIEnumerableImplementations(type, distinctIEnumerableImplementations);
                switch (distinctIEnumerableImplementations.Count)
                {
                    case 0: return false;
                    case 1: return true;
                
                    default:
                        // This may or may not be appropriate for your purposes.
                        throw new NotSupportedException("Multiple IEnumerable<> implementations detected.");
                }
            }
            private static bool IsIEnumerableOfT(Type type)
            {
                return type.IsGenericType
                    && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
            }
            private static void ExtractAllIEnumerableImplementations(Type type, HashSet<Type> implementations)
            {
                foreach (Type interfaceType in type.GetInterfaces())
                {
                    if (IsIEnumerableOfT(interfaceType)) {
                        implementations.Add(interfaceType);
                    }
                    ExtractAllIEnumerableImplementations(interfaceType, implementations);
                }
            }
        }
    }
