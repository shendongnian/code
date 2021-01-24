    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {    
       var listView = (ListView)contextMenuStrip1.SourceControl;
       if (listView.Items.Count == 0)
       {
           e.Cancel = true;
       }
    }
