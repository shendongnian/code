    public class SqlStringHashSet : SqlHashSetBase<string> {
        protected override SqlDbType DbType {
            get { return SqlDbType.NVarChar; }
        }
    }
