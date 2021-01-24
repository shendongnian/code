    public class ClickListener : VectorElementEventListener
    {
        MapView mapView;
        MainActivity activity;
    
        public ClickListener(MainActivity activity)
        {
            this.mapView = activity.mapView;
            this.activity = activity;
        }
    
        public override bool OnVectorElementClicked(VectorElementClickInfo clickInfo)
        {
            Action manipUI = () => {
                var zoomIn = activity.FindViewById<Button>(Resource.Id.zoomIn);
                zoomIn.Text = "+";
            }
            activity.RunOnUIThread(manipUI);
            return true;
        }
    }
