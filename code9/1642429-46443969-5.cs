    public class GeoPoint
    {
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
    }
    public class GeoPointQuery
    {
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
        public double Radius {get; set; }
    }
    public EventsController : ApiController
    {
        public IEnumerable<EventDto> GetEvents([FromUri] GeoPoint geoPoint)
        {
            //how about passing a complex type to the EventService?
            return EventService.GetEventAtPoint(geoPoint).ToDto()  
        }
        public IEnumerable<EventDto> GetEventsQuery([FromUri] GeoPointQuery geoPointQuery)
        {
            //how about passing a complex type to the EventService?
            return EventService.GetEventsWithinDistance(geoPointQuery).ToDto()  
        }
    }
