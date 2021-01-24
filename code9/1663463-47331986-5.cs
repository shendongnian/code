    class SqlMagicAdapter : IMagic {
        SqlMagic m_innerMagic = new SqlMagic();
    
        ITable CreateTable(string name) {
            return new SqlTableAdapter(m_innerMagic.Table.Create(name));
        }
    }
    class SqlTableAdapter : ITable {
        SqlTable m_innerTable;
        public SqlTableAdapter(SqlTable innerTable) {
            m_innerTable = innerTable;
        }
        void AddColumn(Type type, string name) {
            m_innerTable.Columns.Add(type, name);
        }
    }
    class NoSqlMagicAdapter : IMagic {
        NoSqlMagic m_innerMagic = new NoSqlMagic();
    
        ITable CreateTable(string name) {
            return new NoSqlTableAdapter(m_innerMagic.Table.Create(name));
        }
    }
    class NoSqlTableAdapter : ITable {
        NoSqlTable m_innerTable;
        public NoSqlTableAdapter(NoSqlTable innerTable) {
            m_innerTable = innerTable;
        }
        void AddColumn(Type type, string name) {
            m_innerTable.Columns.Add(type, name);
        }
    }
