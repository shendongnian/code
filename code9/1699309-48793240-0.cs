    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems != null)
        {
            bntDeleteFile.Enabled = !Directory.Exists( listView1.SelectedItem );
        }
        else
        {
            bntDeleteFile.Enabled = false;
        }
     }
