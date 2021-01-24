    TextBox textbox = new System.Windows.Forms.TextBox();
    panel.Controls.Add(textbox);
    textbox.Location = new System.Drawing.Point(1, 3);
    textbox.Name = "textBox" + count;
    textbox.TextChanged += TextBox_TextChanged
