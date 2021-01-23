    private Queue<string> q = new Queue<string>();
    private Task readFilesTask;
    public void ReadFiles(string inputDirectory)
    {
        var files = Directory.GetFiles(inputDirectory, "*.txt", SearchOption.TopDirectoryOnly);
        foreach (var file in files)
        {
            var textFromFile = File.ReadAllText(file);
            q.Enqueue(textFromFile);
            File.Delete(file);
        }
    }
    private void start_Click(object sender, EventArgs e)
    {
        readFilesTask = Task.Run(() => ReadFiles("//path/to/dir"));
    }
    private void stop_Click(object sender, EventArgs e)
    {    
        readFilesTask.Wait();
        //readFilesTask.Wait(1000); // if you want kill the task after waiting for 1000 milliseconds
        //Enable buttons
    }
