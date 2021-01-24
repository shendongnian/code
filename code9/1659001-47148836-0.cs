    public class MainActivity : AppCompatActivity, ViewTreeObserver.IOnPreDrawListener
    {
        ...
        fabContainer.ViewTreeObserver.AddOnPreDrawListener(this);
        ...
    
        public bool OnPreDraw()
        {
            //Do your logic 
        }
    }
