    vlcControl1.BeginInit();
    vlcControl1.VlcLibDirectory = new DirectoryInfo(_exeFolder + @"\libvlc\win-x86"); //Make sure your dir is correct
    vlcControl1.VlcMediaplayerOptions = new[] { "-vv"}; //not sure what this does
    vlcControl1.EndInit();
    YourControlContainer.Controls.Add(vlcControl1); //Add the control to your container
    vlcControl1.Dock = DockStyle.Fill; //Optional
    this.vlcControl1.Click += new EventHandler(vlcControl1_Click); //Optional - added a click event .Play()
