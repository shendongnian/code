    public async Task<AnalysisResultArgs[]> MainMethod()
    {
    	var _beansList = new List<AnalysisResultArgs>();
    	
    	for(int i=0; i< 99; i++) // Considering 100 records
    		_beansList.Add(new AnalysisResultArgs());
    
    	var _tasks = new Task<AnalysisResultArgs>[_beansList.Count];
    
    	for (int loopCnt = 0; loopCnt < _beansList.Count; loopCnt++)
    	{
    		var local = loopCnt;
    		_tasks[local] = Task.Run(async() => await ReportResults(_beansList[local].Analyze(new AnalysisResultArgs())));
    	}
    		
    	return await Task.WhenAll(_tasks);
    }
    
    private async Task<AnalysisResultArgs> ReportResults(Task<AnalysisResultArgs> task)
    {
    	await Task.Delay(1000);
    	return await Task.FromResult(new AnalysisResultArgs());
    }
    
    public class AnalysisResultArgs
    {	
    	public async Task<AnalysisResultArgs> Analyze(AnalysisResultArgs newBeanData)
    	{
    		await Task.Delay(1000);
    		return await Task.FromResult(new AnalysisResultArgs());
    	}
    }
