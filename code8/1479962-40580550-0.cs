    namespace Training
    {
        public partial class AddingNewData : Form
        {
            public AddingNewData()
            {
                InitializeComponent();
                fillcombo1();
                fillcombo2();
        }
    
        string original_city, destination_city;
    void fillcombo1()
    {
        string constring = "datasource=localhost;port=3306;username=root;password=root";
        string Query = "SELECT * FROM itemdelivery.fee GROUP BY orig_city;";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
        MySqlDataReader myReader;
        try
        {
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read())
            {
                string storig = myReader.GetString("orig_city");
                comboBox1.Items.Add(storig);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    void fillcombo2()
    {
        // EMPTY
    }
	// just some improvement on query
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        original_city = comboBox1.SelectedItem.ToString();
	    string constring = "datasource=localhost;port=3306;username=root;password=root";
	    string Query = "SELECT DISTINCT dest_city FROM itemdelivery.fee WHERE orig_city = '" + original_city + "' GROUP BY destination_city ;";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
        MySqlDataReader myReader;
        try
        {
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read())
            {
                string stdest = myReader.GetString("dest_city");
                comboBox2.Items.Add(stdest);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
	// this is where I solved the problem
    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        destination_city = comboBox2.SelectedItem.ToString();
	    string constring = "datasource=localhost;port=3306;username=root;password=root";
        string Query = "SELECT del_time FROM itemdelivery.fee WHERE orig_city ='" + original_city + "' AND dest_city ='" + destination_city + "';";
        MySqlConnection conDataBase = new MySqlConnection(constring);
        MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase);
            try
            {
                conDataBase.Open();
                var result = cmdDataBase.ExecuteScalar();
                    if (result != null)
                    {
                        txt_deliverytime.Text = result.ToString();
                    }
                conDataBase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }
    private void txt_deliverytime_TextChanged(object sender, EventArgs e)
    {
    }
}
