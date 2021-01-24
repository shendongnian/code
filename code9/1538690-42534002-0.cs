    ...
    foreach (var image in _imageCollection)
    {
      if (!cancellationToken.IsCancellationRequested)
      {
        currentTask = UploadAsync(...);
        uploadTasks.Add(currentTask);
      }
    }
    await Task.WhenAll(uploadTasks);
    async Task UploadAsync(...)
    {
      string imageName = string.Empty;
      string imagePath = string.Empty;
      ...
    }
