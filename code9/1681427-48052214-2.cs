    private TabPage m_MyTabPage = new TabPage();
    private void checkBox1_CheckStateChanged(object sender, EventArgs e)
    {
        Form1 f1 = new Form1();
        f1.TopLevel = false;
        if (checkBox1.Checked)
        {
            m_MyTabPage.Text = f1.Text;
            tabForms.TabPages.Add(m_MyTabPage);
            tp1.Show();
            f1.Parent = tp1;
            f1.Show();
        }
        else
        {
            tp1.Hide();
            tabForms.TabPages.Remove(m_MyTabPage);
            f1.Dispose();
        }
    }
