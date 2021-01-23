    private async Task GetInformationAsync()
        {
            try
            {
                var task1 = Task.Run(() => GetDataProducts());
                var task2 = Task.Run(() => GetDataCustomers());
                
                await Task.WhenAny(task1, task2);
                _view.OnProgressHandler(this, new ProgressChangedEventArgs(50, "Getting data"));
                await Task.WhenAll(task1, task2);
                _view.OnProgressHandler(this, new ProgressChangedEventArgs(100, "Done"));
                _view.GridProducts.DataSource = await task1;
                _view.GridCustomers.DataSource = await task2;
            }
            catch (Exception ex)
            {
                _view.ShowException(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
