    int i =0; // use local variable for generating controls unique names
    While(readerBE.Read())
    {
        //............
        //........... your code here
        TextBox textBoxBE = new TextBox();
        Label labelBE = new Label();
        textBoxBE.Name = "textBoxBE" + i;
        textBoxBE.Text = readerBE["codeArticleComposant"].ToString();
        textBoxBE.Location = new Point(pointXBE + 35, pointYBE);
        textBoxBE.CharacterCasing = CharacterCasing.Upper;
        textBoxBE.Width = 150;
        labelBE.Text = "BE" + (i + 1).ToString() + " : ";
        labelBE.Location = new Point(pointXBE, pointYBE);
        panelBE.Controls.Add(textBoxBE);
        panelBE.Controls.Add(labelBE);
        panelBE.Show();
        i++; // increment after each read
       
    }
