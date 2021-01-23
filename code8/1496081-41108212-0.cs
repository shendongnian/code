    private async Task<List<EventItemDto>> GetEventsAsync()
    {
        var path = "api/Windows/GetEventNames/";
        var events = new List<EventItemDo>();
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            events = await response.Content.ReadAsAsync<List<EventItemDto>>();
        }
     
        return events;
    }
    private void FillWithEvents(List<EventItemDo> events)
    {
        var eventList = events.Select(event => new ListItemVm<Guid>
                                     {
                                         Id = c.EventId,
                                         Name = c.Title
                                     }).ToList();
        eventsDrp.FillDropDownList<Guid>("Please choose one", eventList, null);
    }
