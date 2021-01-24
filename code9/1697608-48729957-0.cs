            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.VideosLibrary;
            picker.FileTypeFilter.Add(".avi");
            picker.FileTypeFilter.Add(".mp4");
            picker.FileTypeFilter.Add(".mpeg");
            picker.FileTypeFilter.Add(".mov");
            picker.FileTypeFilter.Add(".mkv");
                        
            IReadOnlyList<StorageFile> files = await picker.PickMultipleFilesAsync();
            if (files.Count > 0)
            {
                // doing some needed staff
                StringBuilder output = new StringBuilder("Picked files:\n\n");
                // Application now has read/write access to the picked file(s)
                foreach (StorageFile file in files)
                {
                    output.Append(file.Name + "\n");
                    using (IRandomAccessStream filestream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        output.Append("File SHA256 hash -> " + BytesToString(Sha256.ComputeHash(filestream.AsStreamForRead())) + "\n\n");
                        await filestream.FlushAsync();
                    }
                }
                this.filePickerInfo.Text = output.ToString();                
            }
            else
            {
                this.filePickerInfo.Text = "Operation cancelled.";                
            }    
