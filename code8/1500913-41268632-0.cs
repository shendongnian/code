    public class SerialNumberSearcher
    {
        private readonly DataOrganizerForm _form;  
        public SerialNumberSearcher(DataOrganizerForm form)
        {
            _form = form;
        }
        public void searchSN()
        {
            _form.setNotificationText("Updated text from different class"); 
        }  
    }
