    Form SubLunes = new Form();
            SubLunes.Text = "Día lunes";
            SubLunes.Size = new Size(800, 400);
            SubLunes.StartPosition = FormStartPosition.CenterScreen;
            SubLunes.FormBorderStyle = FormBorderStyle.FixedSingle;
            SubLunes.ShowIcon = false;
            SubLunes.CreateControl();
            SubLunes.ShowDialog();
    
            Button Mañana = new Button();
            Mañana.Location = new System.Drawing.Point(100, 150);
            Mañana.Size = new Size(100, 100);
            Mañana.Text = "Mañana";
            Mañana.Click += new EventHandler(Mañana_Click);
            SubLunes.Controls.Add(Mañana);
