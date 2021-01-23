    public Form1()
    {
        InitializeComponent();
        PopulateCombo(String.Empty);
    }
    
    private void comboBox1_KeyUp(object sender, KeyEventArgs e)
    {
        var hint = comboBox1.Text;
        PopulateCombo(hint);
    }
    
    private void PopulateCombo(string hint)
    {
        comboBox1.Items.Clear();
        var connString = @"Server=.\sqlexpress;Database=NORTHWND;Trusted_Connection=True;";
        using(var con2 = new SqlConnection(connString))
        {
            var query = "select CategoryName from Categories where CategoryName like '%' + @HINT + '%'";
            using (SqlCommand cmd2 = new SqlCommand(query, con2))
            {
                cmd2.Parameters.Add("@HINT", SqlDbType.VarChar);
                cmd2.Parameters["@HINT"].Value = hint.Trim();
                con2.Open();
                var dr2 = cmd2.ExecuteReader();
                while (dr2.Read())
                {
                     comboBox1.Items.Add(dr2.GetString(0));
                }
                //reset cursor to end of hint text
                comboBox1.SelectionStart = comboBox1.Text.Length;
                comboBox1.DroppedDown = true;
            }
        }
    }
