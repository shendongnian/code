    private async void btnCopy_Click(object sender, EventArgs e)
    {
        //check file exists, check destination exists, etc
        string sourceFile = @"C:\a.txt", destinationFile = @"C:\b.txt";
        //Let TPL do the heavy lifting of interacting with disk for I/O
        var copyTask = await CopyFile(sourceFile, destinationFile);
    
        /* 
        //Manual thread instantiation not needed. Hence commented
        Thread fooThread = new Thread((ThreadStart)delegate
        {
            //copy files to destination using method foobarCopy(params)
        });
    
        fooThread.Start();
        */
    
        //if file copy is successful, inform user on GUI.
        if (copyTask)
        {
            //show a message box
        }
    }
    
    private async Task<bool> CopyFile(string sourceFile, string destinationFile)
    {
        bool fileCopiedSuccessfully = true;
        //here use async I/O methods from stream class which support the notion of tasks
        try
        {
            using (FileStream sourceStream = File.Open(sourceFile, FileMode.Open))
            {
                using (FileStream destinationStream = File.Create(destinationFile))
                {
                    //exactly at this point of time when the actual copy happens your GUI thread is completely
                    //free to do anything. It won't freeze.
                    //This work happens on a thread-pool thread which you don't have to worry about.
                    await sourceStream.CopyToAsync(destinationStream);
                }
            }
        }
        catch (IOException ioex)
        {
            fileCopiedSuccessfully = false;
            MessageBox.Show("An IOException occured during copy, " + ioex.Message);
        }
        catch (Exception ex)
        {
            fileCopiedSuccessfully = false;
            MessageBox.Show("An Exception occured during copy, " + ex.Message);
        }
        return fileCopiedSuccessfully ;
    }
