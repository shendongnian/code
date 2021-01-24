    public void UploadAllFiles(IEnumerable<FileUploadParameters> files) {
        var tasks = new List<Task>();
    
        foreach (var file in files) {
            var task = Task.Run(() => {
                UploadFile(file);
            });
    
            tasks.Add(task);
        }
    
        Task.WaitAll(tasks.ToArray());
    }
