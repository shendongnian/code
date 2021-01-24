     static void Main(string[] args)
     {
        Form mainForm = new Form();
        TextBox txtInput = new TextBox();
        txtInput.Height = 50;
        txtInput.Multiline = true;
        txtInput.Dock = DockStyle.Fill;
        Button submitBtn = new Button();
        submitBtn.Text = "Send to Console";
        submitBtn.Dock = DockStyle.Bottom;
        submitBtn.Click += (x, e) =>
        {
            Console.WriteLine(txtInput.Text);
        };
        mainForm.Controls.Add(txtInput);
        mainForm.Controls.Add(submitBtn);
        mainForm.ShowDialog();
     }
