    public class UpdateBackgroundService: BackgroundService
    {
        private readonly DbContext _context;
    
        public UpdateTranslatesBackgroundService(DbContext context)
        {
            this._context= context;
        }
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ...
        }
    }
