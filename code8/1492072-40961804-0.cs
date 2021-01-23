    private void panel1_MouseWheel(object sender, MouseEventArgs e)
    {
            Form2 frm = new Form2();
            panel1.Top += e.Delta > 0 ? 10 : -10;
            
            // tweak this
            if (panel1.Top > 0) panel1.Top = 0;
            else if (panel1.Bottom <= panel1.Parent.Height) panel1.Bottom = panel1.Parent.Height;
            Console.WriteLine("panel2.top:" + panel1.Top);
    }
