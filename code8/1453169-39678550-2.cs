    private void textBox1_TextChanged(object sender, EventArgs e)
    {
           string A = textBox1.Text.Trim();
            string[] Aarry = A.Split('|');
            string cleanedString = "";
            
            for (int i = 0; i < Aarry.Length; i++)
            {
                if (i % 2 == 0)
                    cleanedString += FixText(Aarry[i]) + " ";
                else
                    cleanedString += Aarry[i] + " ";
            }
            textBox2.Text = cleanedString ;
