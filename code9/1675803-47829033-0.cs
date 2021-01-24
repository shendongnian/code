    Process FileGenerator;
    protected void Page_Load(object sender, EventArgs e)
    {
        CallEXE();
        ProcessFiles("filepath");
    }
    private void CallEXE()
    {
        // it generates files and stored the file in shared folder.
        FileGenerator = Process.Start("FileGenerator.Exe");
    }
    private void ProcessFiles(string filePath)
    {
        FileGenerator.WaitForExit();
        //processing files
    }   
