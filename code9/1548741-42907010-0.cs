    public bool exportCSV_DataBuku()
    {
        SaveFileDialog save = new SaveFileDialog();
        save.Filter = "Comma Seperated Values / Excel Document (*.csv)|*.csv|All files (*.*)|*.*";
        save.FilterIndex = 1;
        
        string fileName = save.FileName;
        fileName = fileName.Replace("\\","\\\\");
        if (save.ShowDialog() == DialogResult.OK)
        {
            query = "SELECT * FROM daftar_buku INTO OUTFILE '" + fileName
            + "' FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n'";
        }
        if(this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
            return true;
        } else
        {
            return false;
        }
    }
