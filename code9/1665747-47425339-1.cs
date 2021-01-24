    class KontaktSimpleSpaceListener : SimpleSpaceListener
    {
        Activity context
        public KontaktSimpleSpaceListener(Activity activity)
        {
            this.context = activity; 
        }
    
        public void OnRegionEntered(IBeaconRegion beaconRegion)
        {
            Log.Info(TAG, string.Format("Entered {0} region", beaconRegion.Identifier));
            context.updateTextView("My Data");// pass the string here.
        }
    
        public void OnRegionAbandoned(IBeaconRegion beaconRegion)
        {
            Log.Info(TAG, string.Format("Abandoned {0} region", beaconRegion.Identifier));
            context.updateTextView("My another data");// pass the string here.
        }
    }
