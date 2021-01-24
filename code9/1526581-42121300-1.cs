    socket.OnMessage = message =>
    {
        Dispatcher.Invoke(() => 
        {
            foreach (TabItem item in tabControl.Items)
            {
                if (item.Name == message)
                {
                    MyTab1 tab1 = item.Content as MyTab1;
                    if(tab1 != null)
                        MessageBox.Show(tab1.getInfo());
                }
            }
        });
    };
