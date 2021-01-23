        var point = new Point(label1.Location.X + label1.Width,
            label1.Location.Y);
        var p2 = panel1.Controls[1].Location;
        var ctrl = panel1.GetChildAtPoint(point);
        if (ctrl is TextBox)
        {
            textBox1.Text = "Got TextBox";
        }
        else if (ctrl is Label)
        {
            textBox1.Text = "Got Label";
        }
        textBox1.Text += string.Format(" {0}:{1} {2}:{3}", point.X, point.Y, p2.X, p2.Y);
