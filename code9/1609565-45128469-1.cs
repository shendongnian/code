    public class OperationClass
    {
        private readonly ILogger<OperationClass> _logger;
        private readonly AppDbContext _appDbContext;
        public OperationClass(ILogger<OperationClass> logger, AppDbContext appDbContext)
        {
            if (logger == null) throw new ArgumentNullException(nameof(logger));
            if (appDbContext == null) throw new ArgumentNullException(nameof(appDbContext));
            _logger = logger;
            _appDbContext = appDbContext;
        }
        public void DoOperation()
        {
            try     
            {
                _logger.LogInformation("DoOperation.");
                _appDbContext.PlayNows.Add(new PlayNow
                {
                    DateTime = DateTime.Now
                });
                _appDbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error in DoOperation: {exception}");
            }
        }
    }
