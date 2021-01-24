    public class ProcessTracksJob :IJob 
    {
       private readonly ITracksService _tracksService;
       public ProcessTracksJob(ITracksService tracksService, etc.) 
       {
         _tracksService = tracksService;
         ...
       }
       /// the execute method using the private fields in this class
    }
