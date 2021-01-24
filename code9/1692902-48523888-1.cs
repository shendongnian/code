    Method(fileList, errorList, p => _ViewModel.ProgressBarProp1 = p);
    private static void Method(
        IEnumerable<string> fileList,
        List<Tuple<string, string>> errorList,
        Action<int> reportProgress)
    {
        var progress = 0;
        
        foreach (var file in fileList)
        {
            if (!File.Exists(file))
            {
                errorList.Add(new Tuple<string, string>(file,
                    " does not exist in the folder"));
            }
            reportProgress?.Invoke(++progress);
        }
    }
