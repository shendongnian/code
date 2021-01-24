    private void Tb_Initials_Click(object sender, EventArgs e)
        {
            tb_Initials.Text = '';
            string EngineerName = tb_Name.Text;
            string[] splitted = EngineerName.Split(' ');
            for(int i = 0; i<splitted.Length; i++)
                tb_Initials.Text += splitted[i];
        }
