    public class CreateImportEntity<T> where T : class, new()
    {
        public T CreateAnImportEntity(string[] splitContent, ref int i, out PassedOrFailed passedOrFailed,
                                            out string strException)
        {
            strException = String.Empty;
            var aEntity = new T();
            var errField = String.Empty;
            PropertyInfo[] properties = typeof(T).GetProperties();
            try
            {
                foreach (PropertyInfo property in properties)
                {
                    errField = property.Name;
                    if (typeof(T) == typeof(CasesNorm))
                    {
                        if (property.Name == "AccountsReceivableNorm") //case
                        {
                            break;
                        }
    ...
