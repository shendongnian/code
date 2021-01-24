    public async Task<List<string>> CopyFilesAsync(List<ModelIterationModel> model)
    {
        var copyFileTaskParameters = GetCopyFileTaskParameters(model);
        // do not await tasks here, just get the reference for them
        var fitDataResulLits = CopyFitDataFiles(copyFileTaskParameters, cancellationToken);
        // ...
        // wait for all running tasks
        await Task.WhenAll(copyFileTaskParameters, ...);
        // now all of them are finished
    }
    // note sugnature change
    public async Task CreateConfigFile
    {
        // if you really need to wait for this task after some moment, save the reference for task
        var userFileListModel = _copyFilesToLocalDirectoryService.CopyFilesAsync(temp);
        ...
        // now await it
        await userFileListModel;
        ...
    }
