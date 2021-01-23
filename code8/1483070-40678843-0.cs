    public static void AddItemThreadSafe(this System.Windows.Forms.ListBox lb, object item)
    {
        if (lb.InvokeRequired)
        {
            lb.Invoke(new MethodInvoker(delegate
            {
                lb.Items.Add(item);
                lb.TopIndex = Math.Max(lb.Items.Count - lb.ClientSize.Height / lb.ItemHeight + 1, 0);
                lb.Refresh();
            }));
        }
        else
        {
            lb.Items.Add(item);
            lb.TopIndex = Math.Max(lb.Items.Count - lb.ClientSize.Height / lb.ItemHeight + 1, 0);
            lb.Refresh();
        }
    }
