    [assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
    namespace MyNamespace.Droid
    {
    	public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter, IOnMapReadyCallback
    	{
    		GoogleMap map;
    		List<CustomPin> customPins;
    		bool isDrawn;
    
    		protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
    		{
    			base.OnElementChanged(e);
    
    			if (e.OldElement != null) 
    			{
    				map.InfoWindowClick -= OnInfoWindowClick;
    			}
    
    			if (e.NewElement != null)
    			{
    				var formsMap = (CustomMap)e.NewElement;
    				customPins = formsMap.CustomPins;
    				Control.GetMapAsync(this);
    			}
    		}
    
    		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    		{
    			base.OnElementPropertyChanged(sender, e);
    			if (e.PropertyName.Equals ("VisibleRegion") && !isDrawn) {
    				map.Clear ();
    				foreach (var pin in customPins) {
    					var marker = new MarkerOptions();
    					marker.SetPosition (new LatLng(pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));
    					marker.SetTitle (pin.Pin.Label);
    					marker.SetSnippet (pin.Pin.Address);
    					marker.SetIcon (BitmapDescriptorFactory.FromResource (Resource.Drawable.fake_ic_pin));
    
    					map.AddMarker (marker);
    				}
    				isDrawn = true;
    			}
    		}
    
    		protected override void OnLayout(bool changed, int l, int t, int r, int b)
    		{
    			base.OnLayout(changed, l, t, r, b);
    
    			if (changed)
    			{
    				isDrawn = false;
    			}
    		}
    
    		void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
    		{
    			var customPin = GetCustomPin(e.Marker);
    			if (customPin == null)
    			{
    				throw new Exception("Custom pin not found");
    			}
    
    			if (!string.IsNullOrWhiteSpace(customPin.Url))
    			{
    				var url = Android.Net.Uri.Parse(customPin.Url);
    				var intent = new Intent(Intent.ActionView, url);
    				intent.AddFlags(ActivityFlags.NewTask);
    				Android.App.Application.Context.StartActivity(intent);
    			}
    		}
    
    		void IOnMapReadyCallback.OnMapReady(GoogleMap googleMap) 
    		{ 
    			InvokeOnMapReadyBaseClassHack(googleMap); 
    			map = googleMap;
    			map.SetInfoWindowAdapter(this);
    			map.InfoWindowClick += OnInfoWindowClick;
    		}
    
    		public Android.Views.View GetInfoContents(Marker marker)
    		{
    			return null;
    		}
    
    		public Android.Views.View GetInfoWindow(Marker marker)
    		{
    			return null;
    		}
    
    		CustomPin GetCustomPin(Marker annotation)
    		{
    			var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
    			foreach (var pin in customPins)
    			{
    				if (pin.Pin.Position == position)
    				{
    					return pin;
    				}
    			}
    			return null;
    		}
    
    		void InvokeOnMapReadyBaseClassHack(GoogleMap googleMap)
    		{
    			System.Reflection.MethodInfo onMapReadyMethodInfo = null;
    
    			Type baseType = typeof(MapRenderer);
    			foreach (var currentMethod in baseType.GetMethods(System.Reflection.BindingFlags.NonPublic |
    															 System.Reflection.BindingFlags.Instance |
    															  System.Reflection.BindingFlags.DeclaredOnly))
    			{
    				if (currentMethod.IsFinal && currentMethod.IsPrivate)
    				{
    					if (string.Equals(currentMethod.Name, "OnMapReady", StringComparison.Ordinal))
    					{
    						onMapReadyMethodInfo = currentMethod;
    						break;
    					}
    
    					if (currentMethod.Name.EndsWith(".OnMapReady", StringComparison.Ordinal))
    					{
    						onMapReadyMethodInfo = currentMethod;
    						break;
    					}
    				}
    			}
    
    			if (onMapReadyMethodInfo != null)
    			{
    				onMapReadyMethodInfo.Invoke(this, new[] { googleMap });
    			}
      		}
    	}
    }
