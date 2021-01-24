    namespace ConsoleApp1
    {
        using System;
        using System.Linq;
        using Newtonsoft.Json;
        using System.Data;
        using System.Collections.Generic;
        class Program
        {
            static void Main(string[] args)
            {
                var t = new tbl_CategoryEntity
                {
                    CategoryID = 12,
                    CategoryName = "Hi"
                };
                var collection = new tbl_CategoryEntityCollection();
                collection.Add(t);
                var entityJson = JsonConvert.SerializeObject(t);
                var collectionJson = JsonConvert.SerializeObject(collection);
                Console.WriteLine("Entity = \n" + entityJson);
                Console.WriteLine("Collection = \n" + collectionJson);
                Console.ReadKey();
            }
        }
        public class tbl_CategoryEntity
        {
            private Int32? _CategoryID;
            private String _CategoryName;
            private Int32? _TypeID;
            private Boolean? _IsDel;
            public tbl_CategoryEntity() { }
            public Int32? CategoryID
            {
                get { return _CategoryID; }
                set { _CategoryID = value; }
            }
            public String CategoryName
            {
                get { return _CategoryName; }
                set { _CategoryName = value; }
            }
            public Int32? TypeID
            {
                get { return _TypeID; }
                set { _TypeID = value; }
            }
            public Boolean? IsDel
            {
                get { return _IsDel; }
                set { _IsDel = value; }
            }
        }
        public abstract class EntityCollection<T> : List<T> where T : new()
        {
            private String _OrderColumn;
            private String _Order = "asc";
            private Int32? _PageIndex = 1;
            private Int32? _RowsPage = 10;
            protected readonly Dictionary<string, SqlDbType> _FilterFieldsSqlDbType;
            public String OrderColumn
            {
                get { return _OrderColumn; }
                set { _OrderColumn = value; }
            }
            public String Order
            {
                get { return _Order; }
                set { _Order = value; }
            }
            public Int32? PageIndex
            {
                get { return _PageIndex; }
                set { _PageIndex = value; }
            }
            public Int32? RowsPage
            {
                get { return _RowsPage; }
                set { _RowsPage = value; }
            }
            protected EntityCollection()
            {
                _FilterFieldsSqlDbType = new Dictionary<string, SqlDbType>()
                {
                    { "OrderColumn", SqlDbType.VarChar },
                    { "Order", SqlDbType.VarChar },
                    { "PageIndex", SqlDbType.Int },
                    { "RowsPage", SqlDbType.Int },
                };
            }
            public abstract SqlDbType GetSqlDbType(string PropertyName);
            public abstract bool IsIdentity(string PropertyName);
        }
        public class tbl_CategoryEntityCollection : EntityCollection<tbl_CategoryEntity>
        {
            private static readonly string _IdentityField = "CategoryID";
            private static readonly SqlDbType _IdentitySqlDbType = SqlDbType.Int;
            private readonly Dictionary<string, SqlDbType> _FieldsSqlDbType;
            public tbl_CategoryEntityCollection() : base()
            {
                _FieldsSqlDbType = new Dictionary<string, SqlDbType>()
            {
                { "CategoryID", SqlDbType.Int },
                { "CategoryName", SqlDbType.NVarChar },
                { "TypeID", SqlDbType.Int },
                { "IsDel", SqlDbType.Bit }
            }
                .Union(base._FilterFieldsSqlDbType).ToDictionary(k => k.Key, v => v.Value);
            }
            public static string GetIdentityField()
            {
                return _IdentityField;
            }
            public static SqlDbType GetIdentitySqlDbType()
            {
                return _IdentitySqlDbType;
            }
            public override SqlDbType GetSqlDbType(string PropertyName)
            {
                return _FieldsSqlDbType[PropertyName];
            }
            public override bool IsIdentity(string PropertyName)
            {
                return PropertyName.Equals(_IdentityField);
            }
        }
    }
