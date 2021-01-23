    private List<string> words = new List<string>();
    private void btnEnter_Click(object sender, EventArgs e)
    {
         words.Add(txtEnterWord.Text);
         lstWords.Items.Add(txtEnterWord.Text);
         txtEnterWord.Clear();
    }
