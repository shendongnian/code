    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        foreach (var data in database)
        {
            if (orginalListView.InvokeRequired)
            {
                orginalListView.Invoke(new MethodInvoker(delegate
                {
                    listViewItem = data.value;
                    orginalListView.Items.Add(listViewItem);
                }));
            }
            else
            {
                listViewItem = data.value;
                orginalListView.Items.Add(listViewItem);
            }
        }
    }
