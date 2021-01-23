    public class ExtendedGallery : Gallery
    	{
    		public ExtendedGallery(Context context) : base(context)
    		{
    			
    		}
    
    		public override bool OnFling (MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
    		{
    			//return base.OnFling (e1, e2, velocityX, velocityY);
    			return false;
    		}
    	}
