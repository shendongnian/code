    private void notifyIcon1_Click(object sender, EventArgs e)
    {
        object obj = notifyIcon1.Tag;
        MyObject myObject = (MyObject) obj;
        ShowInTaskbar = true;
        notifyIcon1.Visible = false;
        WindowState = FormWindowState.Normal;
        for (int x = 0; x < dataGridView1.Rows.Count; x++)
        {
            if (dataGridView1.Rows[x].Cells["idObject"].Value.ToString() == myObject.idObject.ToString())
            {
                dataGridView1.Rows[x].Selected = true;
                break;
            }
        }
    }
