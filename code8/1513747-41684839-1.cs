    private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=CHARLIE-PC\MSSQLSERVER1;Initial Catalog=Tema;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fisier (idFisier, Nume, idFolder) VALUES ('"+idFis.Text+ "','"+ numeFis.Text + "','" +idFoldFis.Text +"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
