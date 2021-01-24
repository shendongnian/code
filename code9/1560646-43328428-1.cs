    private void unzip(string path)
    {
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 100;
        progressBar1.Value = 0;
        progressBar1.Visible = true;
        var progressHandler = new Progress<byte>(
            percentDone => progressBar1.Value = percentDone);
        var progress = progressHandler as IProgress<byte>;
        Task.Run(() =>
        {
            var sevenZipPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                Environment.Is64BitProcess ? "x64" : "x86", "7z.dll");
            SevenZipBase.SetLibraryPath(sevenZipPath);
            var file = new SevenZipExtractor(path);
            file.Extracting += (sender, args) =>
            {
                progress.Report(args.PercentDone);
            };
            file.ExtractionFinished += (sender, args) =>
            {
                // Do stuff when done
            };
            //Extract the stuff
            file.ExtractArchive(Path.GetDirectoryName(path));
        });
    }
