    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach(var data in database)
        {
            listViewItem = data.value;
            String name = "orginalListView";
            lock (((ListView)this.Controls[name]))
            {
                //Update UI, invoked because on different thread.
                Invoke(new MethodInvoker(delegate { ((ListView)this.Controls[name]).Items.Add(listViewItem); }));
            }
         }
    }
