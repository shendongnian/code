    if (dr.HasRows)
    {
        while (dr.Read())
        {
            if (dr["Classificacao"] != DBNull.Value)
            {
                totaldevotos += Convert.ToInt32(dr["Classificacao"]);
            }
        }
    }
