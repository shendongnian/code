    private void button2_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrEmpty(text_entrer.Text))
        {
            MessageBox.Show("no montant","EROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        float mont,ope,mont_ht;
        mont = float.Parse(text_entrer.Text); //I HAVE THE PROBLEM HERE
        //..............
    }
