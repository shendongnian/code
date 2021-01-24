    public class Functions
    {
        private static IUnitOfWork _iUnitOfWork;
        public Functions(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }
        public void DoSomething([TimerTrigger("*/30 *  * * * *")] TimerInfo timer, TextWriter log)
        {
            _iUnitOfWork.AuthorRepository.Add(new Author()
            {
                Name = Guid.NewGuid().ToString()
            });
            _iUnitOfWork.Commit();
            var allRecords=_iUnitOfWork.AuthorRepository.GetAll().ToList();
            Console.WriteLine(JsonConvert.SerializeObject(allRecords));
        }
    }
