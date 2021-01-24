    namespace LinqAttributes
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Diagnostics;
        using System.Linq;
    
        public class ColumnInfo
        {
            public string ColumnName { get; set; }
            public string DatabaseType { get; set; }
        }
    
        public class Test
        {
            [System.Data.Linq.Mapping.ColumnAttribute(Name = "Whatever", Storage = "Whatever", DbType = "Char(20)", CanBeNull = true)]
            public string MyProperty { get; set; }
    
            [System.Data.Linq.Mapping.ColumnAttribute(Name = "PEER_UPS#", Storage = "_PEER_UPS_", DbType = "Char(31) NOT NULL", CanBeNull = false)]
            public string PEER_UPS_ { get; set; }
        }
    
        internal class Program
        {
            public static IEnumerable<ColumnInfo> GetColumnsInfo(Type type)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(type))
                {
                    var columnAttribute = descriptor.Attributes
                        .OfType<System.Data.Linq.Mapping.ColumnAttribute>().Single();
    
                    yield return new ColumnInfo
                    {
                        ColumnName = columnAttribute.Name,
                        DatabaseType = columnAttribute.DbType
                    };
                }
            }
    
            private static void Main(string[] args)
            {
                foreach (var item in GetColumnsInfo(typeof(Test)))
                {
                    Debug.WriteLine(item.ColumnName);
                }            
            }
        }
    }
