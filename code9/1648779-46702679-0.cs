    List<T> returnList = new List<T>();
    conn.Open();
    using (SqlCommand sCmd = new SqlCommand(query, conn))
    {
        SqlDataReader dataReader = sCmd.ExecuteReader();
        PropertyInfo[] p = o.GetType().GetProperties();
        while(dataReader.Read())
        {
            T t = new T();
            for (int i = 0; i < p.Length; i++)
            {
                Console.WriteLine(p[i].GetValue(t)+" "+p[i].PropertyType+" "+dataReader[i].GetType());
                p[i].SetValue(t, dataReader[i]);
            }
            returnList.Add(t);
        }
    }
    conn.Close();
    return returnList;
