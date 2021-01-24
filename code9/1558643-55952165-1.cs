    namespace WD.EMP.APP.Droid.Renderer {
        public class GEMapRenderer: MapRenderer {
            protected override void OnMapReady(Android.Gms.Maps.GoogleMap googleMap) {
                base.OnMapReady(googleMap);
                NativeMap.SetPadding(0, 0, 0, 500);
            }
        }
    }
    NativeMap.SetPadding(0,0,0,500 );  
