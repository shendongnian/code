     string cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
     using (SqlConnection con = new SqlConnection(cs))
     {
            SqlCommand cmd = new SqlCommand("SELECT [Consumo_Medio_Real], [Tipo_de_Fatura]  FROM [dbo].[t_faturas]", con);
            con.Open();
