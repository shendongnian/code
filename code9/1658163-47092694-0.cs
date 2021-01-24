    MyLabel label1 = new MyLabel();
    label1.DoubleClick += new EventHandler(MyLabel_Click);
    surface.Controls.Add(label1);
    }
    void MyLabel_Click(object sender, EventArgs e)
    {
    MessageBox.Show("Clicked");
    }
