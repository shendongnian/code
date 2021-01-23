    private void GetInformation()
        {
            try
            {
                var task1 = Task.Run(() => GetDataProducts());
                var task2 = Task.Run(() => GetDataCustomers());
                Task.WhenAll(task1, task2);
                _view.GridProducts.DataSource = task1.Result;
                _view.GridCustomers.DataSource = task2.Result;
            }
            catch (Exception ex)
            {
                _view.ShowException(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _view.DoneTasksWork = true;
                _view.OnProgressHandler(this, new ProgressChangedEventArgs(_view.DoneTasksWork && _view.DoneTasksWork ? 100 : 50, _view.DoneTasksWork && _view.DoneTasksWork ? "Done" : "Getting data"));
            }
        }
