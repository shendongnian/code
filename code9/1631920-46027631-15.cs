     class SqlHelper<T> where T : new()
    {
        private PropertyInfo[] pInfo = typeof(T).GetProperties();
        private string sqlTable = typeof(T).Name; //i've made this filed becouse i've named my classes same as tables in SQL
        public SqlConnection Con { get; set; }
        private StringBuilder sb = new StringBuilder();
        private List<string> columns = new List<string>();
        public SqlHelper(SqlConnection con)
        {
            this.Con = con;
        }
        private void GetNames()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + sqlTable, Con);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    if (!columns.Contains(dr.GetName(i)))
                        columns.Add(dr.GetName(i));
                }
            }
            catch (Exception)
            {
                return;
            }
            finally
            {
                Con.Close();
            }
        }
        public List<T> ReturnSelect()
        {
            List<T> listGen = new List<T>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM " + sqlTable, Con);
            try
            {
                Con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    T obj = new T();
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                            pInfo[i].SetValue(obj, dr.GetValue(i));
                    }
                    listGen.Add(obj);
                }
                return listGen;
            }
            catch (Exception)
            {          
                return null;
            }
            finally { Con.Close(); }
        }
   
        public bool InsertInto(T obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            sb.Clear();
            sb.Append("INSERT INTO " + sqlTable + " VALUES(");
            if (columns.Count == 0)
                GetNames();
            string s1 = ",";
            for (int i = 1; i < columns.Count; i++)
            {
                if (columns.Count - 1 == i)
                    s1 = ")";
                sb.Append("@" + pInfo[i].Name + s1);
                cmd.Parameters.AddWithValue("@" + pInfo[i].Name, pInfo[i].GetValue(obj));
            }
            cmd.CommandText = sb.ToString();
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        public bool Update(T obj)
        {
            sb.Clear();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            sb.Append("UPDATE " + sqlTable + " SET ");
            string s1 = ",";
            if (columns.Count == 0)
                GetNames();
            for (int i = 1; i < columns.Count; i++)
            {
                if (columns.Count - 1 == i)
                    s1 = "";
                sb.Append(columns[i] + "=" + "@" + pInfo[i].Name + s1);
                cmd.Parameters.AddWithValue("@" + pInfo[i].Name, pInfo[i].GetValue(obj));
            }
            sb.Append(" WHERE " + columns[0] + "=" + "@" + pInfo[0].Name + ";");
            cmd.Parameters.AddWithValue("@" + pInfo[0].Name, pInfo[0].GetValue(obj));
            cmd.CommandText = sb.ToString();
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
        public bool Delete(T obj)
        {
            if (columns.Count == 0)
                GetNames();
            string id = $"@{pInfo[0].Name}";
            SqlCommand cmd = new SqlCommand("DELETE FROM " + sqlTable + " WHERE " + columns[0] + "=" + id, Con);
            cmd.Parameters.AddWithValue(id, pInfo[0].GetValue(obj));
            try
            {
                Con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Con.Close();
            }
        }
    }
