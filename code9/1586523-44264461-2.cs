    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var hit = listView1.HitTest(e.Location);
        if (hit.Item != null)
        {
            string file = hit.Item.Text;
            string[] arr1 = null;
            if (File.Exists(file)) arr1 = File.ReadLines(file).ToArray();
            ...
        }
    }
