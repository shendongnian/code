    interface IRepository
    {
        List<string> GetList();    
    }
    class Repository
    {
        List<string> GetList() { return /*Query database here*/ ;}
    }
    public class File_IO
    {
        private IRepository _repository;
        private File_IO(IRepository repository)
        {
             _repository = repository;
        }
    
        public string constructString()
        {
             IList matchList = _repository.GetList();
             .........................
             return result;
        }
    }
