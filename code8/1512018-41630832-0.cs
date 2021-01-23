    string StringaConnessione = @"server=localhost;uid=root;password=XXXX;database=classifica;port=3306;charset=utf8";
    public static MySqlConnection Connessione = newMySqlConnection(StringaConnessione);    
    void MostraBtnClick(object sender, EventArgs e)
    {
        Connessione.Open();
        MySqlCommand cmd = new MySqlCommand
                     {
                      Connection = Connessione,
                      CommandText = "SELECT conduttore,concorrente,razza,taglia,categoria,tempo,errori,assente,eliminato FROM classifiche WHERE taglia='small' AND categoria='agility' AND assente=0 ORDER BY tempo,errori,eliminato ASC"
                      };
        cmd.ExecuteNonQuery();
        MySqlDataAdapter SDA=new MySqlDataAdapter(cmd);
        DataTable DATA= new DataTable();
        SDA.Fill(DATA);
        dataGridView1.DataSource=DATA; 
        Connessione.Close();
    }
