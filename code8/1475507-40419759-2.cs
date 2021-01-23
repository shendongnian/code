     public void startxmo()
     {
        //access dir variable from main form instance in program.cs
        string startfile = program.mainform.dir + "\\xmo.exe";
        Process xmoappli = new Process();
        if (File.Exists(startfile))
        {
            xmoappli.StartInfo.FileName = startfile;
            xmoappli.Start();
        }
        else
        {
            MessageBox.Show("XMO.exe blev ikke fundet på den valgte lokation!");
            File.Delete(program.mainform.dir + "\\xmo.ini");
            dialog();
        }
    }
