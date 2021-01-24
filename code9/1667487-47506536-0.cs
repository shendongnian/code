    private void listView1_MouseClick(object sender, MouseEventArgs e)
    {
        if(e.Button== MouseButtons.Right)
        {
            var hti = listView1.HitTest(e.Location);
            if (hti.Item != null)
                hti.Item.Selected = true;
            contextMenuStrip1.Show(listView1, e.Location);
        }
    }
