    namespace SomeNamespace
    {
        public sealed class SomeClass
        {
            public int Example()
            {
                return (int)Stackoverflow
                    .Solution
                    .SqlExecute(
                        @"anyConnectionStringName", // or null for main connection string
                        @"anyStoredProcedureName",
                        new System
                            .Collections
                            .Generic
                            .Dictionary<string, object>()
                        {
                            { @"field0", "value" },
                            { @"field1", -1.5 },
                            { @"field2", System.DateTime.Now },
                            { @"field3", 3.5 },
                            { @"field4", 7 },
                            { @"field5", System.DBNull.Value },
                        },
                        false // for ExecuteNonQuery or true for ExecuteScalar
                    );
            }
        }
    }
