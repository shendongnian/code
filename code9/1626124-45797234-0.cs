    var items = new List<string>();
    timer.Elapsed += (sender, e) =>
    {
        if (contextMenuStrip1.IsHandleCreated)  // always invoke, but check for handle
            contextMenuStrip1.Invoke(new Action(() =>
            {
                menu1.DropDownItems.Add(e.SignalTime.ToString() + "extra");
                menu1.DropDownItems.Add(e.SignalTime.ToString());
                contextMenuStrip1.Refresh();
            }));
        else
        {
            lock (items)
            {
                items.Add(e.SignalTime.ToString() + "extra");
                items.Add(e.SignalTime.ToString());
            }
        }
    };
    contextMenuStrip1.HandleCreated += (s, e) =>
    {
        lock (items)
        {
            foreach (var item in items)
                menu1.DropDownItems.Add(item);
            contextMenuStrip1.Refresh();
        }
        items = null;
    };
