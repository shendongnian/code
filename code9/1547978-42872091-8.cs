    ....
    // Side note: using statement is the preferred way to handle disposable resources
    // You don't need to call Close and Dispose, it is done automatically at the end of the using block
    // The compiler add the required code and works also in case of exceptions
    using(StreamWriter file = new System.IO.StreamWriter("C:\\MCDFC\\Hosts.txt", true))
    {
         file.WriteLine(textAlias.Text + "#" + textHost.Text);
    }
    MessageBox.Show("Host saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
    textAlias.Text = "";
    textHost.Text = "";
    // If someone subscribe to the event it will receive it...
    HostAdded?.Invoke(textAlias.Text, textHost.Text);
    ....
