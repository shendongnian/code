    private async void ButtonCalculate_Counterpart_Click(object sender, EventArgs e)
    {
        // This is how you use "ConnectToCounterpart"
        byte[] replyBytes = await ConnectToCounterpart(@"checksum folder1\folder2\file.txt");
        // "async" makes the given method "asyncronous", so that it runs parallel to other processes
        // "await" will prevent an "acync method" from "halting" or "blocking" the main process.
        // If you want the reply as a normal string
        string replyString = Encoding.UTF7.GetString(replyBytes, 0, replyBytes.Length);
            
        // If you want the reply as a checksum
        string checkSum = BitConverter.ToString(replyBytes);
    }
