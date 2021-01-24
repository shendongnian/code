    public string[] getColumnsName()
    {
        List<string> listacolumnas=new List<string>();
        using (SqlConnection connection = new SqlConnection(Connection))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = 'Usuarios' and t.type = 'U'";
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }
            }
        return listacolumnas.ToArray();
    }
