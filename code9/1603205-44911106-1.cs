        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                string txt1 = tb.Text;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = (@"INSERT INTO MIEMBROS_Comments (COMM_USER_ID, COMM_CONTENIDO, COMM_FECHA, COMM_USER_NOMBRE, COMM_USER_FOTO, COMM_POST_ID) VALUES ('"
                + user_id + "','" + txt1 + "','" + COMM_fecha + "','" + usrnom + "','" + usrfoto + "','" + postid + "');");
                cmd.Connection = conn;
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }
        traerposts();
    }
