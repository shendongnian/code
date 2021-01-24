    public class Consumer {
        private IRepositoryLocator RepositoryLocator;
    
        public Consumer(IRepositoryLocator RepositoryLocator) {
            this.RepositoryLocator = RepositoryLocator;
        }
    
        public Response<string> EventsAccept(EventsAlertsRequest logMsgId) {
          IEventsRepository<EventsModel> eventsRepo = (IEventsRepository<EventsModel>)RepositoryLocator.GetRepositoryObject(STMEnums.RepositoryName.EventsTableRepository.ToString());
          EventsModel eventmodel = new EventsModel();
          eventmodel = eventsRepo.GetEventsByEventId(eachlogMsgId);
          return EventStatusChangeResponse;
        }
    }
