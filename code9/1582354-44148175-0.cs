    public class MainActivity : Activity, IImageLoadingListener
    {
        //Your ListView and Adapter
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            // Set your ListView and Adapter here
             
            ImageLoader imageloader = ImageLoader.Instance;
            imageloader.Init(ImageLoaderConfiguration.CreateDefault(this));
            
            foreach (var card in cards)
            {          
                imageloader.LoadImage(card.imageUrl, this);
            }            
        }
    
        public void OnLoadingCancelled(string p0, View p1)
        {
        }
    
        public void OnLoadingComplete(string p0, View p1, Bitmap p2)
        {
            foreach (var card in cards)
            {
               if (card.imageUrl == p0)
               {
                  card.image = p2;
                  adapter.NotifyDataSetChanged();
               }               
            }
        }
    
        public void OnLoadingFailed(string p0, View p1, FailReason p2)
        {
        }
    
        public void OnLoadingStarted(string p0, View p1)
        {
        }
    }
