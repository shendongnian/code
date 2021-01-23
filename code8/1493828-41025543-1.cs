    public class SqlHashSet : SqlHashSetBase<int> {
        protected override SqlDbType DbType {
            get { return SqlDbType.Int; }
        }
    }
