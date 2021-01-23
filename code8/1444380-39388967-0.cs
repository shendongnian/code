     public static List<T> GetFilteredData<T>(ColumnView view)
            {
                List<T> resp = new List<T>();
                for (int i = 0; i < view.DataRowCount; i++)
                    resp.Add((T)view.GetRow(i));
    
                return resp;
            }
