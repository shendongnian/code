     using (SqlConnection conn = Conexion.Conectado())
            {
                
                string strsql = "SELECT dbo.Personas.Nombres, dbo.Personas.Apellidos, dbo.Prestamo.prestamo_id, dbo.Prestamo.fecha, dbo.Prestamo.Monto_prestamo, dbo.Prestamo.Ruta, dbo.Prestamo.Quotas, dbo.Prestamo.Balance, dbo.Registro_pagos.Monto_pago, dbo.Registro_pagos.Mora FROM dbo.Personas INNER JOIN dbo.Prestamo ON dbo.Personas.Persona_id = dbo.Prestamo.fk_Persona_id INNER JOIN dbo.Registro_pagos ON dbo.Prestamo.prestamo_id = dbo.Registro_pagos.fk_prestamo_id where dbo.Registro_pagos.fecha_pago like '" + Dtp_fecha_cuadre.Value.ToString("yyyy-MM-dd") +"'";
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.CommandType = CommandType.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string Nombres = dr["Nombres"].ToString();
                    string Apellidos = dr["Apellidos"].ToString();
                    string num_prestamo = dr["prestamo_id"].ToString();
                    DateTime fecha = Convert.ToDateTime(dr["fecha"].ToString());
                    double Monto_prestamo = Convert.ToDouble(dr["Monto_prestamo"].ToString());
                    string Codigo_ruta = dr["Ruta"].ToString();
                    string Quotas = dr["Quotas"].ToString();
                    double Balance = Convert.ToDouble(dr["Balance"].ToString());
                    double Monto_pago = Convert.ToDouble(dr["Monto_pago"].ToString());
                    double Mora = Convert.ToDouble(dr["Mora"].ToString());
                    Dgv_cuadre_rutas.Rows.Add(Nombres, Apellidos, num_prestamo, fecha, Monto_prestamo, Codigo_ruta, Quotas, Balance, Monto_pago, Mora);
                }
                conn.Close();
