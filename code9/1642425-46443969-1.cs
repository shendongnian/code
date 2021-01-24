    public class GeoPoint
    {
        public double Latitude { get; set; } 
        public double Longitude { get; set; }
    }
    public EventsController : ApiController
    {
        //action is only selected when URI contains required parameters to bind a GeoPoint instance
        public IEnumerable<EventDto> GetEvents([FromUri] GeoPoint geoPoint) {
            //how about passing a complex type to the EventService?
            return EventService.ReadEvent(geoPoint).ToDto()  
        }
    }
