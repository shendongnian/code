    var task =  System.Threading.Tasks.Task.Factory.StartNew(() =>
        this._httpService.CreateRecord(new Uri(Configuration.Current.CreateRecordUrl), httpObj)).ContinueWith(
            (response) =>
            {
                if (!response.IsFaulted)
                {
                    if (httpObj.CallBack != null)
                    {
                        httpObj.CallBack(response.Result);
                    }
                }
                else {
                    this._logger.Error("There was some error which causes the task to field");
                }
            });
    task.Wait();  // Wait till your Task has finished.
