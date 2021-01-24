    private void button1_Click(object sender, EventArgs e)
    {
        textBoxCount += 1;
        TextBox t3 = new TextBox();
        t3.Top = 20 + (22 * textBoxCount); //You can put your own logic to set the Top of textbox.
        t3.Left = 120;
        t3.Width = 50;
        t3.Height = 20;
        t3.Name = "txtwaste" + textBoxCount; //You can use your own logic of creating new name.
        this.Controls.Add(t3);
        this.textBoxes.Add(t3);
    }
