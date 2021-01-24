        startbutton.Click += async (sender, e) =>
        {                
            // Instantiate the CancellationTokenSource
            cts = new CancellationTokenSource();
            try
            {
                // **** GET ****
               var jsonData = await LoadDataAsync(cts.Token);
               // ** Parse data into your entity ****
               var items = GetData(jsonData);
               // **** Create your adapter passing the data *****
               listview.Adapter = new EnglishMonarchAdapter(this, items);
            }
            catch (TaskCanceledException)
            {
                textView0.Text = " Download deleted ";
            }
            catch (Exception)
            {
                textView0.Text = "Generic Error";
            }
            // ***Set the CancellationTokenSource to null when the download is complete.
            cts = null;
        };
