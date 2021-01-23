    public class SpeedLog
    {
       ISpeed speed;
       ILogger logger;
       public SpeedLog(ISpeed speed, ILogger logger)
       {
           this.speed = speed;
           this.logger = logger;
       }
       public void Information()
       {
           logger.Information($"{speed.GetType().Name} is running with {speed.Speed()}");
       }
    }
    
