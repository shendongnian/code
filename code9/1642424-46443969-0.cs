    public EventsController : ApiController
    {
        public IEnumerable<EventDto> GetEvents([FromUri] double? latitude, [FromUri] double? longitude) {
             
            //code validating method parameters
            return EventService.ReadEvent(Latitude.Value, Longitude.Value).ToDto()  
        }
    }
