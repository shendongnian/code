    private List<ProcessedEventsData> eventList;
 
    private void SetDataParsingView()
    {
        if(this.eventList == null)
        {
            this.eventList = preprocessingViewModel.Events.ToList();
        }
        ContentControlDataContext = eventList.Any() ? new DataParsingViewModel(preprocessingViewModel.Events.ToList()) : new DataParsingViewModel();
    }
