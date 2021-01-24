    private void btnRemove_Click(object sender, EventArgs e)
    {
        string folder = themesF.Find(t=> t.Equals(lb.SelectedItem.Text));
        themesF.Remove(folder);
        lb.DataSource = themesF;
        System.IO.Directory.Delete(@"Thems\" + folder,true);
    }
