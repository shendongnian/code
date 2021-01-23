    private void button1_Click(object sender, EventArgs e)
    {
        using(SqlConnection con = new SqlConnection(@"Data Source=CHARLIE-PC\MSSQLSERVER1;Initial Catalog=Tema;Integrated Security=True;"))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Fisier (idFisier, Nume, idFolder) VALUES (@idFis,@numeFis,@idFoldFis)",con);
            cmd.Parameters.Add("@idFis", SqlDbType.NVarChar, -1).Value = idFis.Text;
            cmd.Parameters.Add("@numeFis", SqlDbType.NVarChar, -1).Value = numeFis.Text;
            cmd.Parameters.Add("@idFoldFis", SqlDbType.NVarChar, -1).Value = idFoldFis.Text;
            cmd.ExecuteNonQuery();
        }
    }
