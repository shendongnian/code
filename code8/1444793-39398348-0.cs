    private void SendFilesButton_Click(object sender, EventArgs e)
    {
        if (SendTask.Status == TaskStatus.Created)
        {
            SendTask.Start();
            SendFilesButton.Enabled = false;
        }
    }
