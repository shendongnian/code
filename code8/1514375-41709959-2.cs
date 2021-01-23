    public static int RegistrarSoporteIndicador(SoporteIndicador soporteIndicador)
            {
                int Ingreso = 0;
                using (SqlConnection conexion = Conexion.ObtenerConexion())
                {
                    using (SqlCommand cmd = new SqlCommand("PA_Guardar_Registro", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("CodigoIM", soporteIndicador.CodigoIM);
                        cmd.Parameters.AddWithValue("CodigoGI", soporteIndicador.CodigoGI);
                        SqlParameter imageParam = cmd.Parameters.Add("@Soporte", System.Data.SqlDbType.VarBinary);
                        imageParam.Value = soporteIndicador.Soporte;
                        cmd.Parameters.AddWithValue("NombreSoporte", soporteIndicador.NombreSoporte);
                        cmd.Parameters.AddWithValue("UsuarioRegistro", soporteIndicador.UsuarioRegistro);
                        cmd.Parameters.AddWithValue("FechRegistro", soporteIndicador.FechRegistro);
    
                        
                        Ingreso = cmd.ExecuteNonQuery();
                        conexion.Close();
                    }
                }
                SqlConnection cerrarcon = Conexion.CerrarConexion();
                return Ingreso;
            }
