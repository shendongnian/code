    List<Task<ImageResult>> imageResultTasks = new List<Task<ImageResult>>();
    for (int imageIndex = 0; imageIndex < ..)
    {
        imageResultTasks.Add(GetThumbnailForRow(...);
    }
    // await for all to finish:
    await Task.WhenAll(imageResultTasks);
    IEnumerable<ImageResult> imageResults = imageResulttasks
        .Select(imageResultTask => imageResultTask.Result);
    foreach (var imageResult in imageResults)
    {
        ProcesImageResult(imageResult);
    }
