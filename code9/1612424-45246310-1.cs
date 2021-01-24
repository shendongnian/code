    // Required for For System.Linq.Enumerable.Select<TSource,TResult>
    // https://developer.xamarin.com/api/member/System.Linq.Enumerable.Select%7BTSource,TResult%7D/p/System.Collections.Generic.IEnumerable%7BTSource%7D/System.Func%7BTSource,TResult%7D/
    using System.Linq;  
    public class LatLngDTO
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public static implicit operator LatLng(LatLngDTO latLng)
        {
            if (latLng == null)
                return null;
            return new LatLng(latLng.Latitude, latLng.Longitude);
        }
        public static implicit operator LatLngDTO(LatLng latLng)
        {
            if (latLng == null)
                return null;
            return new LatLngDTO { Latitude = latLng.Latitude, Longitude = latLng.Longitude };
        }
    }
    public class Id
    {
        [JsonProperty(PropertyName = "$oid")]
        public string id { get; set; }
    }
    public class MapRoute
    {
        public Id _id { get; set; }
        public string RouteName { get; set; }
        public List<LatLngDTO> RouteWaypoints { get; set; }
    }
