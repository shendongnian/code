    private void OnCreated(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            image.Dispatcher.Invoke(new Action(() => { image.Source = LoadBitmapImage(e.FullPath); }));
            
        }
    public static BitmapImage LoadBitmapImage(string fileName)
        {
            while (!IsFileReady(fileName))
            {
                Thread.Sleep(100);
            }
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = stream;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
                return bitmapImage;
            }
        }
    public static bool IsFileReady(String sFilename)
            {
                // If the file can be opened for exclusive access it means that the file
                // is no longer locked by another process.
                try
                {
                    using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        return (inputStream.Length > 0);   
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
