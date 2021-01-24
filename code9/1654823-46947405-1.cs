    [STAThread]
    private static void Main() {
        Application.EnableVisualStyles();
        //form things
        TextBox tbx = new TextBox();
        Form form = new Form();
        tbx.TextChanged += Tbx_TextChanged;
        form.Controls.Add(tbx);
        form.Show();
        
        Application.Run(form);
        Console.ReadLine();
    }
    private static void Tbx_TextChanged(object sender, EventArgs e) {
        TextBox tbx = sender as TextBox;
        Console.Write(tbx.Text);
    }
