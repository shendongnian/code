    public interface IUnitOfWork : IDispose
    {
    	void BeginTransaction();
    	void Commit();
    }
    
    
    public class EmailService : IEmailService
    {
    
        private IUnitOfWork unitOfWork;
        private IEventLoggerService MailCheckerLog;
        private ISMTPService SMTPService;
    
        public EmailService(... IUnitOfWork unitOfWork ..)
        {
            this.unitOfWork = unitOfWork;
            //Other stuff
        }
    
        public void Update(tb_Email obj)
        {
            IUnitOfWork unitOfWork2;
            using (unitOfWork2.BeginTransaction())
            {
                unitOfWork2.EmailRepository.Update(obj);
                unitOfWork2.Commit();
            }
        }
    }
