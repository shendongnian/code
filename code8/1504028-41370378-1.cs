    private void button3_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (string c in ListArticle.Clothes)
            {
                MessageBox.Show(c);
            }
        }
        catch
        {
            MessageBox.Show("Articles is null.");
        }
    }
