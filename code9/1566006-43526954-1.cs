    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace UnitTestProject3
    {
        [TestClass]
        public class FetchChunkTest
        {
            [TestMethod]
            public void FetchChunk()
            {
                var fetchTypes = new List<Type>
                {
                    typeof(string),
                    typeof(int),
                    typeof(float)
                };
    
                var chunk = FetchChunk(5, fetchTypes);
            }
    
            private static IEnumerable<KeyValuePair<Type, List<dynamic>>> FetchChunk(int retries, IEnumerable<Type> fetchTypes)
            {
                foreach (var fieldType in fetchTypes)
                {
                    var method = typeof(DBRepository).GetMethod("GetAll");
                    var generic = method.MakeGenericMethod(fieldType);
                    var entities = generic.Invoke(null, new object[] {"*"}) as List<dynamic>;
                    yield return new KeyValuePair<Type, List<dynamic>>(fieldType, entities);
                }
            }
        }
    
        internal class DBRepository
        {
            public static IEnumerable<dynamic> GetAll<T>(string columnNames = "*")
            {
                return new List<dynamic> {"test", 12, 34.2, true};
            }
        }
    }
