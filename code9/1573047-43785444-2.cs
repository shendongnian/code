     private async void buttonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string elapsedTime = string.Empty;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            tokenSource = new CancellationTokenSource();
            int lineCount = textBoxInput.LineCount;
	        var outputResult = String.Empty;
			
            for (int cnt = 0; cnt < lineCount; cnt++)
            {
	            var lineToProcess = textBoxInput.GetLineText(cnt);
				//Code inside task will work in thread from thread pool, so the UI thread shouldn't be blocked
                string result = await Task.Run(() => 
					EncryptDecrypt.Encrypt(lineToProcess), tokenSource.Token);
				outputResult += result;
            }
			//When completed update the UI with encrypted text.
			//UI context here
	        textBoxOutput.Text = outputResult;
			stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            time.Content = elapsedTime;
        }
