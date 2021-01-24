        public async Task OpenFileWithAsync(string path)
        {
            var file = await StorageFile.GetFileFromPathAsync(path);
            if (file != null)
            {
                var options = new LauncherOptions();
                options.DisplayApplicationPicker = true;
                var success = await Launcher.LaunchFileAsync(file, options);
                if (success)
                {
                    //File Launched
                }
                else
                {
                    //File Launch Failed
                }
            }
        }
