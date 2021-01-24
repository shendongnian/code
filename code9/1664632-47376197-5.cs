    private void btnHTMLParse_Click(object sender, EventArgs e)
    {
        foreach (var tag in GetTagsFromHtml(txtHTML.Text))
            dataGridView1.Rows.Add(tag);
    }
    
    private IEnumerable<string> GetTagsFromHtml(string text)
    {
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
                yield return tag.ToString();
            }
        }
    }
