    private void Encode()
    {
        Job j = new Job();
        MediaItem m = new MediaItem(txtBxVideoFilePath.Text);
        Source s = m.Sources[0];
        s.Clips[0].StartTime = new TimeSpan(0, 0, 5);
        s.Clips[0].EndTime = new TimeSpan(0, 0, 10);
        j.OutputDirectory= @"C:\Users\MyOutputDir\";
        j.MediaItems.Add(m);
        j.Encode();
        txtBxOutputDir.Text = j.ActualOutputDirectory; //Path to your videofile
    }
