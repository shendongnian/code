        public List<Tuple<T, T2, T3, T4>> QueryMultiple<T2, T3, T4>(string sql, object param)
            where T2 : class
            where T3 : class
        {
            using (var con = new SqlConnection(GetConnStr()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var query = con.Query<T, T2, T3, T4, Tuple<T, T2, T3, T4>>(sql, (t, t2, t3, t4) => Tuple.Create(t, t2, t3, t4), param);
                //if (query.Count() == 0)
                //    return new List<T>();
                var data = query.ToList();
                con.Close();
                con.Dispose();
                return data;
            }
        }
