     public static class ReportHelper
    {
      
        public static DataTable ToDataTable<T>(this IList<T> items)
        {
            var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                tb.Rows.Add(values);
            }
            return tb;
        }
        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type type)
        {
            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type type)
        {
            if (type != null && IsNullable(type))
            {
                if (!type.IsValueType)
                {
                    return type;
                }
                else
                {
                    return Nullable.GetUnderlyingType(type);
                }
            }
            else
            {
                return type;
            }
        }
        static TableLogOnInfo crTableLogonInfo;
        static ConnectionInfo crConnectionInfo;
        static Tables crTables;
        static Database crDatabase;
        public static void ReportLogin(ReportDocument crDoc, string Server, string Database, string UserID, string Password)
        {
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = Server;
            crConnectionInfo.DatabaseName = Database;
            crConnectionInfo.UserID = UserID;
            crConnectionInfo.Password = Password;
            crDatabase = crDoc.Database;
            crTables = crDatabase.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            {
                crTableLogonInfo = crTable.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogonInfo);
            }
        }
        //No Login
        public static void ReportLogin(ReportDocument crDoc, string Server, string Database)
        {
            crConnectionInfo = new ConnectionInfo();
            crConnectionInfo.ServerName = Server;
            crConnectionInfo.DatabaseName = Database;
            crConnectionInfo.IntegratedSecurity = true;
            crDatabase = crDoc.Database;
            crTables = crDatabase.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
            {
                crTableLogonInfo = crTable.LogOnInfo;
                crTableLogonInfo.ConnectionInfo = crConnectionInfo;
                crTable.ApplyLogOnInfo(crTableLogonInfo);
            }
        }
    }
