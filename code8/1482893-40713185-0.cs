    private void buttonNewRow_Click(object sender, EventArgs e)
    {
        DateTimePicker date = new DateTimePicker();
        int count = panel1.Controls.OfType<DateTimePicker>().ToList().Count;
        date.Location = new Point(0, 15 * count);
        date.Size = new Size(91, 20);
        panel1.Controls.Add(date);
        //Textbox 1
        TextBox textboxTranspo = new TextBox();
        textboxTranspo.Location = new Point(576, 45 * count);
        textboxTranspo.Size = new Size(81, 20);
        panel1.Controls.Add(textboxTranspo);
        //Textbox 2
        TextBox textboxDaily = new TextBox();
        textboxDaily.Location = new Point(663, 45 * count);
        textboxDaily.Size = new Size(81, 20);
        panel1.Controls.Add(textboxDaily);
        //Textbox 1 + Textbox 2 result
        TextBox textboxTotal = new TextBox();
        textboxTotal.Location = new Point(772, 45 * count);
        textboxTotal.Size = new Size(100, 20);
        panel1.Controls.Add(textboxTotal);
        EventHandler textChanged = (o, e) => {
            int intTranspo, intDaily;
            if (int.TryParse(textboxTranspo.Text, out intTranspo)
             && int.TryParse(textboxDaily.Text, out intDaily))
                textboxTotal.Text = (intTranspo + intDaily).ToString();
        };
        textboxTranspo.TextChanged += textChanged;
        textboxDaily.TextChanged += textChanged;
    }
