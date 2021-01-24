    class cConexion
    {
        private static SqlConnection conexion;
        public static SqlConnection getConexion()
        {
            if (conexion != null)
            {
                return conexion;
            }
            conexion = new SqlConnection(Properties.Settings.Default.MyConnectionString);
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error" + e.Message);
                return null;
            }
        }
        public static void cerrarConexion()
        {
            if (conexion != null)
            {
                conexion.Close();
            }
        }
    }
