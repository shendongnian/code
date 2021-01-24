    bool cancel = false; // set to true to cancel the transfer
    session.FileTransferProgress +=
        (sender, e) =>
        {
            if (cancel)
            {
                e.Cancel = true;
            }
        };
    session.PutFiles(localPath, remotePath).Check();
