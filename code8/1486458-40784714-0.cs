    void ModificaBtnClick(object sender, EventArgs e)
    {
        Connessione.Open();
        MySqlCommand cmd = new MySqlCommand("UPDATE GARA set nome_gara=@nomegara,giudice=@giudice,località=@localita,data=@data ...",Connessione);
        cmd.Parameters.AddWithValue("@nomegara", textBox1.Text);
        cmd.Parameters.AddWithValue("@giudice", textBox2.Text);
        ...
        cmd.ExecuteNonQuery();
        MessageBox.Show("Dati modificati correttamente!");
    }
    void CancellaBtnClick(object sender, EventArgs e)
    {
        Connessione.Open();
        MySqlCommand cmd =new MySqlCommand("DELETE FROM GARA WHERE Field = @value, ...",Connessione);
       
        cmd.Parameters.AddWithValue("@value", ...);
        ...
        cmd.ExecuteNonQuery();
        MessageBox.Show("Dati cancellati correttamente!");
    }
