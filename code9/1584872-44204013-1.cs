    //Inside main Form.  Click button to open new form
    private void button1_Click(object sender, EventArgs e)
    {
          Form2 f2 = new Form2();
          f2.FormClosed += F2_FormClosed;
          f2.Show();
    }
    private void F2_FormClosed(object sender, FormClosedEventArgs e)
    {
        MessageBox.Show("Form was closed");
    }
