	private void btnAddCoarse_click(object sender, EventArgs e)
    {
           //MessageBox.Show(listBox1.SelectedItem.ToString());
           string query1 ="SELECT ogrenciNo FROM ders,ogrenci,Enrollment WHERE ogrenciId=ogrenciNo AND dersId=dersKodu AND ogrenci.email='" + mainform.Username + "' AND Enrollment.dersId='"+listBox1.SelectedValue+"'";
           string query = "INSERT INTO Enrollment(dersId,ogrenciId) VALUES (@dersId, @ogrenciId)";
			
			
			
           using (connection = new SqlConnection(connectionString))
		   {
				int result=0;
				using (SqlCommand command = new SqlCommand(query1, connection))
				{
					connection.Open();
				
					result=Convert.ToInt32(command.ExecuteScalar());
					connection.Close();
				}
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					connection.Open();
				
					command.Parameters.AddWithValue("@dersId", listBox1.SelectedValue);
					command.Parameters.AddWithValue("@ogrenciId",result);
					command.ExecuteNonQuery();
					PopulateList2();
				}
			}
    }
