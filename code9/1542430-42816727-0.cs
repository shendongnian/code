    public IEnumerator GetCSVCoroutine(System.Action<string[,]> OnFinished)
    {
        var downloader = new WWW("csvurl.com/csvfile.csv");
        yield return downloader;
        var fileText = downloader.text;
        string[,] csvGrid = CSVReader.SplitCsvGrid(fileText);
        OnFinished(csvGrid);
    }
