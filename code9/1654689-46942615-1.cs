    private void Form1_Shown(object sender, EventArgs e)
    {
        var items = new[] { "Item One", "Item Two", "Item Three", "Item Four", "Item Five" };
    
        for (int i = 0; i < items.Length; i++)
        {
            var btn = new Button
            {
                Text = $"Button {i + 1}",
                Tag = items[i]
            };
    
            btn.Click += (object obj, EventArgs args) 
                =>
                {
                    MessageBox.Show($"Hello.  {((Button)obj).Tag}");
                };
    
            flowLayoutPanel1.Controls.Add(btn);
        }
    }
