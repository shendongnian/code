    private void btnHTMLParse_Click(object sender, EventArgs e)
    {
        var text = txtHTML.Text;
        var position = 0;
    
        while (position < text.Length)
        {
            if (text[position++] == '<')
            {
                StringBuilder tag = new StringBuilder();
                while (position < text.Length && text[position] != '>')
                {
                    tag.Append(text[position]);
                    position++; //advance in tag
                }
                dataGridView1.Rows.Add(tag.ToString());
            }
        }
    }
