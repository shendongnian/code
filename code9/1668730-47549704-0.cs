    private void Form1_Load(object sender, EventArgs e)
    {
        for (int y = 0; y <= 13; y++)
        {
            for (int i = 0; i <= 13; i++)
            {
                Button ruta = new Button();
                ruta.Location = new Point(0 + (i * 50), 0 + (y * 50));
                ruta.Size = new Size(50, 50);
                ruta.AutoSize = false;
                ruta.Text = "";
                ruta.TabStop = false;
                ruta.Click += ruta_click;
                list.Add(ruta);
                this.Controls.Add(ruta);
            }
        }
    }
    private void ruta_click(object sender, EventArgs e)
    {
        txtBox.Text = list.IndexOf((Button)sender) + "";
    }
