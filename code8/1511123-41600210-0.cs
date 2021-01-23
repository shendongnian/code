    private async void Loading_Shown(object sender, EventArgs e)
    {
        label2.Text = "Step 1...";
        await Task.Run(() =>
        {
            // different thread
            filePresent = Directory.Exists(contentPath);
            if (!filePresent) Directory.CreateDirectory(contentPath);
        });
        // back on UI thread
        if (filesPresent == false)
        {
            label2.Text = "Downloading Files..."; });
               
            Home form = new Home();
            form.Visible = true;
        }
        else{
            Home form = new Home();
            form.Visible = true;
        }
    }
