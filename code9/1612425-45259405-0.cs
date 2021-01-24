using Android.Gms.Maps.Model;
     namespace App3.Model
     {
        public class LatLngDTO
        {
          public double Latitude { get; set; }
          public double Longitude { get; set; }
          public LatLngDTO(double lat,double lng)
          {
            Latitude = lat;
            Longitude = lng;
           }
           public static LatLng ToLatLng(LatLngDTO latLng)
           {
             if (latLng == null)
                return null;
             else
                return new LatLng(latLng.Latitude, latLng.Longitude);
            }
            public static LatLngDTO ToLatLngDTO(LatLng latLng)
            {
              if (latLng == null)
                return null;
              else
                return new LatLngDTO(latLng.Latitude, latLng.Longitude);
            }
        }
