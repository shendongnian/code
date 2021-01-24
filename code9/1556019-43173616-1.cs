    public class ScheduledJobRegistry: Registry
    {
        public ScheduledJobRegistry(DateTime appointment)
        {
          //Removed the following line and replaced with next two lines
          //Schedule<SampleJob>().ToRunOnceIn(5).Seconds();
          IJob job = new SampleJob();
          JobManager.AddJob(job, s => s.ToRunOnceIn(5).Seconds());
        }
    }
        [HttpPost]
        [Route("Schedule")]
        public IHttpActionResult Schedule([FromBody] SchedulerModel schedulerModel)
        {
            JobManager.Initialize(new ScheduledJobRegistry());                       
            JobManager.StopAndBlock();
            return Json(new { success = true, message = "Scheduled!" });
        }
