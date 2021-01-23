    public List<string> LoadList()
    {
    List<string> tagsList = new List<string>();
    using (SqlConnection connection = new SqlConnection(ADados.StringDeConexao))
    {
    connection.Open();
    using (SqlCommand command = connection.CreateCommand())
    {
    command.CommandText = "SELECT column FROM table";
    using (SqlDataReader reader = command.ExecuteReader())
    {
    while (reader.Read())
    {
    if (!reader.IsDBNull(0))
    tagsList.Add(reader.GetString(0));
    }
    reader.Close();
    }
    connection.Close();
    return tagsList;
    }
