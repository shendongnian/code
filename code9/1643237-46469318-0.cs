    private const string connPath = "datasource=localhost;username=root;password='';database=lms;";
        public MySqlConnection MyConn = new MySqlConnection(connPath);
        public DataTable selectQuery(string query)
        {
            DataTable dTable = new DataTable();
            try
            {                
                MySqlCommand MyCommand = new MySqlCommand(query, MyConn);
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyCommand;
                MyAdapter.Fill(dTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dTable;
        }
    DataTable mem = selectQuery("SELECT image FROM `mem_det` WHERE Member_id=1");
            int count = mem.Rows.Count;
            if (count > 0)
            {
                var data = (Byte[])(mem.Rows[count - 1]["image"]);
                var stream = new MemoryStream(data);
                memberImage.Image = Image.FromStream(stream);
            }
