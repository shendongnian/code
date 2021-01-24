    var chunkSize = 8000000;
    byte[] bb = new byte[chunkSize];
    using (var file = File.OpenWrite(filename))
    {
        while (true)
        {
            var bytesReceived = control.Receive(bb);
            file.Write(bb, 0, bytesReceived);
            if (bytesReceived < chunkSize)
                break;
        }
    }
    MessageBox.Show("download success!");
