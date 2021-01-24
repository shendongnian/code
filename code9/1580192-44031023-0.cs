        ListViewItem addItem = null;
        ControlInvoke(lsView, () => addItem = lsView.Items.Add(txt));
        ControlInvoke(lsView, () => addItem.SubItems[0].ForeColor = oColor ?? Color.Black);
        ControlInvoke(lsView, () => lsView.EnsureVisible(lsView.Items.Count - 1));
        ControlInvoke(lsView, () => lsView.Refresh());
----------
    delegate void UniversalVoidDelegate(); 
    public static void ControlInvoke(Control control, Action function)
    {
        if (control.IsDisposed || control.Disposing)
            return;
        if (control.InvokeRequired)
        {
            control.Invoke(new UniversalVoidDelegate(() => ControlInvoke(control, function)));
            return;
        }
        function();
    }
