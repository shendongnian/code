    public static async Task Run(DurableOrchestrationContext ctx)
    {
    	var classInfo = ctx.GetInput<ClassInfo>();
    	var targetDateTime = DateTime.Parse(classInfo.ClassEndDateString);
    	var maxTimeSpan = new TimeSpan(96, 0, 0);
        using (var timeoutCts = new CancellationTokenSource())
        {
    		while(true)
    		{
    			TimeSpan timeLeft = targetDateTime.Subtract(ctx.CurrentUtcDateTime);
    			if(timeLeft <= TimeSpan.Zero) {
    				break;
    			}
    			
    			DateTime checkTime; 
    			if(timeLeft > maxTimeSpan) {
    				checkTime = ctx.CurrentUtcDateTime.Add(maxTimeSpan);
    			} else {
    				checkTime = ctx.CurrentUtcDateTime.Add(timeLeft);
    			}
    			
    			Task durableTimeout = ctx.CreateTimer(checkTime, timeoutCts.Token);
    
    			Task<bool> cancellationEvent = ctx.WaitForExternalEvent<bool>("Cancellation");
    			if (cancellationEvent == await Task.WhenAny(cancellationEvent, durableTimeout))
    			{
    				timeoutCts.Cancel();
    				return
    			}
    		}
    		await ctx.CallActivityAsync("SendEmail", classInfo.ClassData);
        }
    }
    
    public class ClassInfo {
    	public string ClassEndDateString {get; set; }
    	public string ClassData {get; set;}
    } 
