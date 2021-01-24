    private readonly ConcurrentDictionary<string, byte> _filesInProgress = new ConcurrentDictionary<string, byte>();
    private async Task GetNewFiles(CancellationToken cancellationToken) {            
        if (!cancellationToken.IsCancellationRequested) {
            var newfiles = Directory.GetFileSystemEntries(inputDirectory, "*.pdf", SearchOption.AllDirectories);
            foreach (var file in newfiles) {
                // TryAdd returns true if key was not already in dictionary
                if (_filesInProgress.TryAdd(file, 0) && File.Exists(file)) {
                    Task.Factory.StartNew(() => {
                        ProcessFile(file);                         
                        _filesInProgress.TryRemove(file, out _);
                    }, cancellationToken);
                }
            }
            await Task.Delay(frequency, cancellationToken);
            if (!cancellationToken.IsCancellationRequested) {
                GetNewFiles(cancellationToken);
            }
        }
    }
