    public class EmailService : IEmailService
    {
    
        private IUnitOfWork unitOfWork;
    
        public EmailService()
        {
            unitOfWork = new UnitOfWork();
        }
    
        public List<tb_Email> SelectAll(int batchAge, int batchSize)
        {
            return unitOfWork.EmailRepository.SelectAll(batchAge, batchSize).ToList();
        }
    
        public tb_Email SelectByID(Guid id)
        {
                return unitOfWork.EmailRepository.SelectByID(id);
        }
    
        public void Update(tb_Email obj)
        {
            IUnitOfWork unitOfWorkUpdate;
            using (unitOfWorkUpdate = new UnitOfWork())
            {
                unitOfWorkUpdate.EmailRepository.Update(obj);
                unitOfWorkUpdate.Commit();
            }
        }
    
    }
