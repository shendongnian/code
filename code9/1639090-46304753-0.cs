    private void viewPeopleTimLog()
    {
        string message;
        
        dtgPeopleTimLog.ItemsSource = null;
    
        PeopleTimeLogList logList = new PeopleTimeLogList(out message);
        if(string.IsNullOrEmpty(message)) //Everything is fine
        {
            dtgPeopleTimLog.ItemsSource = logList;
        }
        else
        {
             //Code to print the exception message here
        }
    }
    
