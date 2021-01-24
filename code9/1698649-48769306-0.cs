    int i = 1;
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("button1 clicked!");
        ButtonAutomationPeer peer = new ButtonAutomationPeer(button1);
        IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
        i++;
        if (i != 4)
        {
            invokeProv.Invoke();
        }
        else
        {
            i = 1;
        }
    }
