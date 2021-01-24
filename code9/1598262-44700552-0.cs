    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.Sql;
    namespace My_Entity.Abstracts
    {
        using My_Entity.Interfaces;
        public abstract class Entity<T> : List<T>, IEntity where T : new()
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
            public Entity()
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
    }
