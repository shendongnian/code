    private void ReportResults(AnalysisResultArgs results)
    {
         /* Do some serial operations */
    }
    ...
    _tasks = new Task<AnalysisResultArgs>[_beansList.Count];
    for (int loopCnt = 0; loopCnt < _beansList.Count; loopCnt++)
    {
        var count = loopCnt;
        _tasks[count] = Task.Run(() =>
        {
            var results = _beansList[count].Analyze(newBeanData);
            ReportResults(results);
            return results;
        });
    }
    // do some housekeeping when all tasks are complete          
    await Task.WhenAll(_tasks);
