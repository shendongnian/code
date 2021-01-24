    static void OnLmChanged(object sender, EventArgs args)
    {
        if (!f1.Visible)
        {
            f2 = new Form1(f1.listBox2.Items, f1.listBox3.Items, f1.label7.Text);
            f2.Show();
            f2.FormClosing += OnFormChanged;
        }
    }
