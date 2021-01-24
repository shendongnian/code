        private async void GetHDMT2_Click(object sender, RoutedEventArgs e)
        {
            if (outputFolder == null)
            {
                var folderPicker = new Windows.Storage.Pickers.FolderPicker();
                folderPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
                folderPicker.FileTypeFilter.Add("*");
                outputFolder = await folderPicker.PickSingleFolderAsync();
                if (outputFolder != null)
                {
                    Windows.Storage.AccessCache.StorageApplicationPermissions.
                    FutureAccessList.AddOrReplace("PickedFolderToken", outputFolder);
                }
                else
                {
                }
            }
            if (mylat.Count > 0)
            {
                await GetImagesAsyncHD2();
            }
        }
        private async Task GetImagesAsyncHD2()
        {
            // Make a dictionary with html code string (with street view iframe inside .
            var Width = 4000;
            var Height = 2000;
            Dictionary<int,string> urls = SetUpURLListHD(Width, Height);
            //Code to estimate time for completely loading the first page (compute a time to use in await task.delay, and the size of first frame nextly used to know if image is pixelised or not (street view fisnish loading or not)
            SoftwareBitmap softwareBitmap = null;
            InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
            BitmapDecoder decoder = null;
            var k = 0;
            WebView saveWebView = new WebView();
            saveWebView.Width = Width;
            saveWebView.Height = Height;
            TopGrid.Children.Add(saveWebView);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            long elapsed_time=0;
            saveWebView.NavigateToString(urls[0]);
            await Task.Delay(10);
            bool equals = false;
            bool findeq = false;
            int t = 0;
            int countTrue = 0;
            bool checka = false;
            List<byte[]> bytes400a = null;
            List<byte[]> bytes400b = null;
            await saveWebView.CapturePreviewToStreamAsync(stream);
            decoder = await BitmapDecoder.CreateAsync(stream);
            softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            bytes400a = GetPixelsP(softwareBitmap);
            while (countTrue < 20)
            {
                await Task.Delay(50);
                if (checka)
                {
                    await saveWebView.CapturePreviewToStreamAsync(stream);
                    decoder = await BitmapDecoder.CreateAsync(stream);
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    bytes400a = GetPixelsP(softwareBitmap);
                    checka = false;
                }
                else
                {
                    await saveWebView.CapturePreviewToStreamAsync(stream);
                    decoder = await BitmapDecoder.CreateAsync(stream);
                    softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                    bytes400b = GetPixelsP(softwareBitmap);
                    checka = true;
                }
                t = t + 1;
                equals = EqualsByte(bytes400a, bytes400b);
                if (equals)
                {
                    countTrue = countTrue + 1;
                }
                if ((equals) && (findeq == false))
                {
                    k = t;
                    elapsed_time = stopwatch.ElapsedMilliseconds;
                    SlidetimeCompute.Value = elapsed_time;
                    findeq = true;
                }
                if (equals == false) { findeq = false; }
            }
            stopwatch.Stop();
            var elapsed_timeForTest = stopwatch.ElapsedMilliseconds;
            await SaveSSAsync(softwareBitmap, "0");
            ulong firstFrameSize = await GetSizePicAsync("0");
            TopGrid.Children.Remove(saveWebView);
            stream.Dispose();
            softwareBitmap.Dispose();
            double timeTowait = (double)elapsed_time;
            timeTowait = Math.Round(timeTowait / 4);
            // prepare somes grids
            var nj = 7;
            List<Grid> grids = new List<Grid>();
            Grid tmpgrid0 = new Grid();
            grids.Add(tmpgrid0);
            Grid tmpgrid1 = new Grid();
            grids.Add(tmpgrid1);
            Grid tmpgrid2 = new Grid();
            grids.Add(tmpgrid2);
            Grid tmpgrid3 = new Grid();
            grids.Add(tmpgrid3);
            Grid tmpgrid4 = new Grid();
            grids.Add(tmpgrid4);
            Grid tmpgrid5 = new Grid();
            grids.Add(tmpgrid5);
            Grid tmpgrid6 = new Grid();
            grids.Add(tmpgrid6);
            Grid tmpgrid7 = new Grid();
            grids.Add(tmpgrid7);
            Grid tmpgrid8 = new Grid();
            grids.Add(tmpgrid8);
            Grid tmpgrid9 = new Grid();
            grids.Add(tmpgrid9);
            Grid tmpgrid10 = new Grid();
            grids.Add(tmpgrid10);
            Grid tmpgrid11 = new Grid();
            grids.Add(tmpgrid11);
            Grid tmpgrid12 = new Grid();
            grids.Add(tmpgrid12);
            Grid tmpgrid13 = new Grid();
            grids.Add(tmpgrid13);
            Grid tmpgrid14 = new Grid();
            grids.Add(tmpgrid14);
            Grid tmpgrid15 = new Grid();
            grids.Add(tmpgrid15);
            Grid tmpgrid16 = new Grid();
            grids.Add(tmpgrid16);
            // add tasks
            List<Task> tasks = new List<Task>();
            for (var i = 1; i < nj+1; i++)
            {
                TopGrid.Children.Add(grids[i]);
                await Task.Delay(1000);
                tasks.Add(await AddTaskAsync(i, nj, Width, Height, firstFrameSize,outputFolder, grids[i], urls, timeTowait)
                    );
            }
            // await all tasks
            await Task.WhenAll(tasks);
        }
        public static async Task<Task> AddTaskAsync(int i, int nj, int width, int height, ulong firstFrameSize, StorageFolder folder, Grid grid, Dictionary<int, string> urls, double timeTowait)
        {
            var t0 = Task.Run(async () =>
            {
                for (var j = i; j < urls.Count; j = j + nj)
                    await ProcessURLHD1Async(urls[j], j, width, height, firstFrameSize, folder, grid, timeTowait);
            });
            await Task.Delay(200);
            return t0;
        }
        public static async Task ProcessURLHD1Async(string url, int i, int width, int height, ulong firstFrameSize, StorageFolder folder, Grid grid, double timeTowait)
        {
            try
            {
                var Dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
                await grid.Dispatcher.RunTaskAsync(async () =>
                {
                    var saveWeb1 = new WebView(WebViewExecutionMode.SeparateThread)
                    {
                        Width = width,
                        Height = height
                    };
                    grid.Children.Add(saveWeb1);
                    saveWeb1.NavigateToString(url);
                    //give street view some delay to load
                    await Task.Delay((int)timeTowait*5);
                    var kk = 0;
                    var pixelised = true;
                    SoftwareBitmap softwareBitmap = null;
                    InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
                    BitmapDecoder decoder = null;
                    while (pixelised == true)
                    {
                        await saveWeb1.CapturePreviewToStreamAsync(stream);
                        decoder = await BitmapDecoder.CreateAsync(stream);
                        softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                        StorageFile file_Save = await folder.CreateFileAsync(i + ".jpg", CreationCollisionOption.ReplaceExisting);
                        if (file_Save != null)
                        {
                            using (var streamF = await file_Save.OpenAsync(FileAccessMode.ReadWrite))
                            {
                                BitmapEncoder encoder = await BitmapEncoder.CreateAsync(Windows.Graphics.Imaging.BitmapEncoder.JpegEncoderId, streamF);
                                encoder.SetSoftwareBitmap(softwareBitmap);
                                await encoder.FlushAsync();
                            }
                        }
                        var basicProperties = await file_Save.GetBasicPropertiesAsync();
                        ulong thissize = basicProperties.Size;
                        while (thissize < 21)
                        {
                            await Task.Delay(100);
                            basicProperties = await file_Save.GetBasicPropertiesAsync();
                            thissize = basicProperties.Size;
                        }
                        if ((thissize > 0.7 * firstFrameSize) || kk > 10)
                        {
                            pixelised = false;
                        }
                        else
                        {
                            await Task.Delay((int)timeTowait*2);
                            kk = kk + 1;
                        }
                    }
                    stream.Dispose();
                    softwareBitmap.Dispose();
                    grid.Children.Clear();
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
