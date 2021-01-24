    private async void ButtonCalculate_Counterpart_Click(object sender, EventArgs e)
    {
        // This is how you use the method
        byte[] replyBytes = await ConnectToCounterpart(@"folder\file.txt");
        // "async" makes the given method "asyncronous", so that it runs parallell to other tings 
        // "await" will prevent a time-consumeing method-call from "halting" or "blocking" the main process.
        // Check if things went wrong
        if (replyBytes == new byte { 1 }) // As mentioned ealier in the backgroundWorker code
        {
            MessageBox.Show("Something went wrong with the hashing. Is the path correct?", "Could not hash")
            return;
        }
        // If you want the reply as a normal string
        string replyString = Encoding.UTF7.GetString(replyBytes, 0, replyBytes.Length);
            
        // If you want the reply as a checksum
        string checkSum = BitConverter.ToString(replyBytes);
     }
