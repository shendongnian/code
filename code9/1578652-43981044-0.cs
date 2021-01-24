        public interface ILoggingRepository : IDisposable
        {
            void LogMessage(string message);
        }
    
        // LoggingRepository.cs
        public class LoggingRepository : ILoggingRepository
        {
            MyDbContext db;
            public LoggingRepository(MyDbContext db)
            {
                this.db = db;
            }
    
            public void Dispose()
            {
                db.Dispose();
            }
    
            public void LogMessage(string message)
            {
                
                var serviceLog = new MonitoringServiceLog() { Message = message, Logged = DateTime.UtcNow };
                db.MonitoringServiceLogs.Add(serviceLog);
                db.SaveChanges();
                
            }
        }
