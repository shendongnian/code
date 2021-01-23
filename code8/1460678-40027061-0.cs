    public class Processing : BaseJobExecutor<PayloadModel>, IJobExecutor<PayloadModel>
    {
    	public Processing(JobPingPong job) : base(job, JobStatus.Processing) {}
    
    	public void Handle()
    	{
    		JobInfo.JobStatus = JobStatus.ExtProcessing;
    		JobInfo.HangfireParentJobId = JobInfo.HangfireJobId;
    		Payload.PostToQueueText(@"http://localhost:8080/api/clone");
    
    		// Pause the current job (this is the parent job) so the outside web service has a chance to complete...
    		var enqueuedIn = new TimeSpan(0, 6, 0, 0);  // 6 hours out...
    		JobPutOnHold(JobInfo.HangfireJobId, enqueuedIn);
    
    		// The next status to be executed upon hydration...
    		JobInfo.JobStatus = JobStatus.Complete;
    		Job.CachePut();
    
    		// Signal the job executor that this job is "done" due to an outside process needing to run...
    		JobInfo.JobStatus = JobStatus.Handoff;
    	}
    }
    public void JobPutOnHold(string jobId, TimeSpan enqueuedIn)
    {
    	var jobClient = new BackgroundJobClient();
    	jobClient.ChangeState(jobId, new ScheduledState(enqueuedIn));
    }
