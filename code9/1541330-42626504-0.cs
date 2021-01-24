    public class MainPageCS : MasterDetailPage
    {
        MasterPageCS masterPage;
    
        public MainPageCS ()
        {
            masterPage = new MasterPageCS ();
            Master = masterPage;
            Detail = new NavigationPage (new ContactsPageCS ());
        }
    }
