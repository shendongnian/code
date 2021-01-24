    public static MySqlConnection ObtenerConexion()
    {
        MySqlConnection Conectar = null;
    
        try
        {
            Conectar = new MySqlConnection(yourFirstConnectionString);
            Conectar.Open();
        }
        catch
        {
            try
            {
                Conectar = new MySqlConnection(yourSecondConnectionString);
                Conectar.Open();
            }
            catch{ }
        }
        return Conectar;
    }
