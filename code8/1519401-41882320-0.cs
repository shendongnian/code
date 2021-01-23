	private void btn_normalizar_Click(object sender, EventArgs e)
	{
		using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
		{
			conn.Open();
			string sql = "SELECT ART_DESIG from Arterias where ART_COD = '10110'";
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				SqlDataReader leitor = cmd.ExecuteReader();
				while (leitor.Read())
				{
					tb_localidade.Text = leitor["ART_DESIG"].ToString();
				}
			}
		}
	}
