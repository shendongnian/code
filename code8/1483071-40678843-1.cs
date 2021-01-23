    private static readonly Object obj = new Object();
    
    public static void AddItemThreadSafe(this System.Windows.Forms.ListBox lb, object item)
    {
        if (lb.InvokeRequired)
        {
            lb.Invoke(new MethodInvoker(delegate
            {
                lock (obj)
                {
                    // thread unsafe code
                    lb.Items.Add(item);
                    lb.TopIndex = Math.Max(lb.Items.Count - lb.ClientSize.Height / lb.ItemHeight + 1, 0);
                }        
            }));
        }
        else
        {
            lock (obj)
            {
                // thread unsafe code
                lb.Items.Add(item);
                lb.TopIndex = Math.Max(lb.Items.Count - lb.ClientSize.Height / lb.ItemHeight + 1, 0);
            }
        }
    }
