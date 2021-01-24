    public static class DTODataHelper
    {
        public static DataTable GetDataOfType(DB2 db, string[] fields, Type type)
        {
            var method = typeof(DTODataHelper).GetMethod("GetData").MakeGenericMethod(type);
            var result = method.Invoke(null, new object[] { db, fields }) as DataTable;
            return result;
        }
        public static DataTable GetData<T>(DB2 db, string[] fields)
        {
            var dtoType = typeof(T);
            var source = Mapper.Configuration.GetAllTypeMaps().Where(i => i.DestinationType == dtoType).Select(i => i.SourceType).FirstOrDefault();
            if (source == null)
                throw new HMException("Не найден источник данных");
            var dbSet = db.Set(source);
            var querable = dbSet.AsQueryable();
            var list = dbSet.ProjectTo<T>().ToList();
            return GetDataTable(list, fields);
        }
        public static DataTable GetDataTable<T>(IEnumerable<T> varlist, string[] fields)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            var hasColumnFilter = fields != null && fields.Length > 0;
            if (varlist == null) return dtReturn;
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = rec.GetType().GetProperties();
                    var excludedProperties = new List<PropertyInfo>();
                    foreach (PropertyInfo pi in oProps)
                    {
                        if (hasColumnFilter && !fields.Contains(pi.Name))
                        {
                            excludedProperties.Add(pi);
                            continue;
                        }
                        Type colType = pi.PropertyType;
                        if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        var piName = pi.GetCustomAttributes().OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? pi.Name;
                        dtReturn.Columns.Add(new DataColumn(piName, colType));
                    }
                    if (excludedProperties.Count > 0)
                    {
                        oProps = oProps.Except(excludedProperties).ToArray();
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    var piName = pi.GetCustomAttributes().OfType<DisplayNameAttribute>().FirstOrDefault()?.DisplayName ?? pi.Name;
                    dr[piName] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }
    }
