    private void button2_Click(object sender, EventArgs e)
    {
        Byte[] IMAGES = null;
        FileStream STREAM = new FileStream(IMGLOCATION, FileMode.Open, FileAccess.Read);
        BinaryReader BSR = new BinaryReader(STREAM);
        IMAGES = BSR.ReadBytes((int)STREAM.Length);
        CON.Open();
        string SQLQUERY = "INSERT INTO USERS (FULNAME,USERNAME,PASSWORD,IMAGE,STATUS)VALUES(@name, @username, @password, @IMG, @status)";
        CMD = new SqlCommand(SQLQUERY,CON);
        CMD.Parameters.AddWithValue("@name", textBox2.Text);
        CMD.Parameters.AddWithValue("@username", textBox1.Text);
        CMD.Parameters.AddWithValue("@password", textBox3.Text);
        CMD.Parameters.Add(new SqlParameter("@IMG", IMAGES));
        CMD.Parameters.AddWithValue("@status", textBox4.Text);
        int N = CMD.ExecuteNonQuery();
        CON.Close();
        MessageBox.Show("USER CREATED SUCCESSFULLY");
    }
