        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                var result = GetColumnsInfo(typeof(Test)).ToList();
            }
    
            public static IEnumerable<ColumnInfo> GetColumnsInfo(Type type)
            {
                foreach (var fld in type.GetProperties()
                    .Where(c => Attribute.IsDefined(c, typeof(System.Data.Linq.Mapping.ColumnAttribute))))
                {
                    var descriptor = TypeDescriptor.GetProperties(type)[fld.Name];
                    var columnAttribute = descriptor.Attributes
                        .OfType<System.Data.Linq.Mapping.ColumnAttribute>().Single();
    
                        yield return new ColumnInfo
                        {
                            ColumnName = columnAttribute.Name,
                            DatabaseType = columnAttribute.DbType
                        };
                    
                }
            }
        }
    
       public class Test
        {
            [System.Data.Linq.Mapping.ColumnAttribute(Name="PEER_UPS#", Storage="_PEER_UPS_", DbType="Char(31) NOT NULL", CanBeNull=false)]
            public string PEER_UPS_ { get; set; }
    
            [System.Data.Linq.Mapping.ColumnAttribute(Name = "Whatever", Storage = "Whatever", DbType = "Char(20)", CanBeNull = true)]
            public string MyProperty { get; set; }
        }
    
        public class ColumnInfo
        {
            public string ColumnName { get; set; }
            public string DatabaseType { get; set; }
        }
