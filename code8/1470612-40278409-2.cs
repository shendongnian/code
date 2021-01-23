    private async Task<ImageResult> GetThumbnailForRow(...)
    {
        var taskImageFromWeb = DownloadFromWebAsync(...);
        // you don't need the result right now
        var taskImageFromFile = GetFromFileAsync(...);
        DoSomethingElse();
        // now you need the images, start for both tasks to end:
        await Task.WhenAll(new Task[] {taskImageFromWeb, taskImageFromFile});
        var imageFromWeb = taskImageFromWeb.Result;
        var imageFromFile = taskImageFromFile.Result;
        ImageResult imageResult = ConvertToThumbNail(imageFromWeb, imageFromFile);
        return imageResult;
    }
