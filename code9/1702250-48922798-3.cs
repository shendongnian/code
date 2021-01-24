    Dictionary<TextBox, TextBox> Textboxes = new Dictionary<TextBox, TextBox>();
    
    int nbrTextBoxBE = int.Parse(textBoxNbrBE.Text);
    panelBE.Controls.Clear();
    panelBE.Focus();
    for (int i = 0; i < nbrTextBoxBE; i++)
    {
        TextBox textBoxArticleCodeBE = new TextBox();
        TextBox textBoxDesignationBE = new TextBox();
        textBoxCArticleCodeBE.Name = "ArticleCodeBE" + (i + 1);
        textBoxDesignationBE.Name = "DesignationBE" + (i + 1);
        textBoxArticleCodeBE.Text = "";
        textBoxDesignationBE.Text = "";
        panelBE.Controls.Add(textBoxArticleCodeBE);
        panelBE.Controls.Add(textBoxDesignationBE);
        Textboxes.Add(textBoxArticleCodeBE, textBoxDesignationBE);
        panelBE.Show();
    }
