    public static class DataContextExtensions {
        public static IEnumerable<dynamic> ExecuteQuery(this DataContext ctx, string query, DbParameter[] parameters = null) {
            using (var cmd = ctx.Connection.CreateCommand()) {
                cmd.CommandText = query;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                ctx.Connection.Open();
                using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)) {
                    while (rdr.Read()) {
                        dynamic row = new DynamicRow();
                        for (int i = 0; i < rdr.FieldCount; i++) {
                            row[rdr.GetName(i)] = rdr[i];
                        }
                        yield return row;
                    }
                }
            }
        }
        /// <summary>
        /// DynamicRow class is similiar to ExpandoObject but with addition of indexer
        /// </summary>
        public class DynamicRow : DynamicObject {
            private readonly Dictionary<string, object> _data = new Dictionary<string, object>();
            public object this[string propertyName] {
                get {
                    object result = null;
                    TryGetMember(propertyName, out result);
                    return result;
                }
                set { TrySetMember(propertyName, value); }
            }
            public override bool TryGetMember(GetMemberBinder binder, out object result) {
                return TryGetMember(binder.Name, out result);
            }
            private bool TryGetMember(string propertyName, out object result) {
                return _data.TryGetValue(propertyName.ToLower(), out result);
            }
            public override bool TrySetMember(SetMemberBinder binder, object value) {
                return TrySetMember(binder.Name, value);
            }
            private bool TrySetMember(string propertyName, object value) {
                _data[propertyName.ToLower()] = value;
                return true;
            }
        }
    }
