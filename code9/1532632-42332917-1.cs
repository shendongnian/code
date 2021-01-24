    public bool passwordFound = false; 
    public void btnCheckPassword_Click(object sender, EventArgs e)
    {
       // your sql actions:
       try
        {
            SqlDataAdapter sdf = new SqlDataAdapter ("select count (*)from password where password = '" + PasstextBox.Text + "'",con);
            DataTable dt = new DataTable();
            sdf.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Password correct");
                this.Hide();
                passwordFound = true;
                // this.Close()  you can also.
            }
            else
            {
                MessageBox.Show("Booyaa Says Wrong Password", "Wrong Password", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        catch (Exception ex)
        {
