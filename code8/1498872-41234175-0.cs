            var uri = new System.Uri("ms-appx:///Assets/test.txt");
            var sampleFile = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(uri);
            var lines = await Windows.Storage.FileIO.ReadLinesAsync(sampleFile);
            if (lines.Count > 0)
            {
                for(int i = 0; i< lines.Count; i++)
                {
                    Message.Text += lines[i];
                }                
            }
