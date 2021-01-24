    public class YourClass
    {
        public Progress<ZipProgress> _progress;
        public YourClass()
        {
            // Create the progress object in the constructor, it will call it's ReportProgress using the sync context it was constructed on.
            // If your program is a UI program that means you want to new it up on the UI thread.
            _progress = new Progress<ZipProgress>();
            _progress.ProgressChanged += Report
        }
    
        private void Report(object sender, ZipProgress zipProgress)
        {
            //Use zipProgress here to update the UI on the progress.
        }
    
        //I assume you have a `Task.Run(() => Download(url, filePathDir);` calling this so it is on a background thread.
        public void Download(string url, string filePathDir)
        {
            WebClient wc = new WebClient();
            Stream zipReadingStream = wc.OpenRead(url);
            ZipArchive zip = new ZipArchive(zipReadingStream);
            ZipFileExtensions.ExtractToDirectory(zip, filePathDir, _progress);
        }
    
        //...
