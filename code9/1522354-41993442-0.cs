    async void OpenFile(object sender, EventArgs e)
        {
            try
            {
                FileData filedata = await CrossFilePicker.Current.PickFile();
            }
            catch (Exception ex)
            {
                ExceptionHandler.ShowException(ex.Message);
            }
        }
