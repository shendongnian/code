    public class MyXamarinFormsPage
    {
        public MyXamarinFormsPage()
        {
            String DBPath = await DependencyService.Get<IFileAccessHelper>().GetDBPathAndCreateIfNotExists()
            //Store string for path
        }
            
        public interface IFileAccessHelper
        {
            Task<String> GetDBPathAndCreateIfNotExists();
        }
    }
