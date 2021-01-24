    public async void RenderingWidget()
    {
        ConcurrentDictionary<string, EngineChangedEventArgs> controlsToConfigure = new ConcurrentDictionary<string, EngineChangedEventArgs>();
        List<Task> tasks = new List<Task>();
        foreach (var engines in MainWindow.ViewModel.RelationalDataManagerList.Values)
        {
            Dictionary<string, FrameworkElement> controlcollection = CurrentDashboardReport.WidgetCollection;
            tasks.Add(Task.Run(() =>
            {
                Parallel.ForEach(controlcollection, item =>
                {
                    try
                    {
                        try
                        {
                            controlsToConfigure.TryAdd(item.Key, FetchDataInParallel(MainWindow.ViewModel.RelationalDashboardReportList[engines.DataSourceName].Reports, item.Key));
                        }
                        catch (Exception ex)
                        {
                            ExceptionLog.WriteExceptionLog(ex, null);
                            throw new ParallelException(ex, item.Key);
                        }
                    }
                    catch (ParallelException ex)
                    {
                        exceptions.Enqueue(ex);
                        ExceptionLog.WriteExceptionLog(ex, GeneratedQueryText);
                    }
                });
                if (exceptions.Count > 0)
                {
                    foreach (var nonRenderedControls in exceptions)
                    {
                        controlsToConfigure.TryAdd(nonRenderedControls.ReportName, FetchDataInParallel(CurrentDashboardReport.Reports, nonRenderedControls.ReportName));
                    }
                }
            }));
        }
        await Task.WhenAll(tasks);
        foreach (var control in controlsToConfigure)
        {
            (CurrentDashboardReport.WidgetCollection[control.Key] as DashboardDataControl).CurrentDashboardReport.OnActiveColumnsChanged(control.Value);
        }
    }
