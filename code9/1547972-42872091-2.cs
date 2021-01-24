    using(StreamWriter file = new System.IO.StreamWriter("C:\\MCDFC\\Hosts.txt", true))
    {
         file.WriteLine(textAlias.Text + "#" + textHost.Text);
    }
    MessageBox.Show("Host saved", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
    textAlias.Text = "";
    textHost.Text = "";
    // If someone subscribe to the event it will receive it...
    HostAdded?.Invoke(textAlias.Text, textHost.Text);
