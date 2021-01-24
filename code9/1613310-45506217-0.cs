    public class CustomUnityContainer : UnityContainer
    {
    
        private bool inDispose = false;
    
        protected override void Dispose(bool disposing)
        {
            if (inDispose) //prevents recursive calls into Dispose
                return;
    
            inDispose = true;
    
            base.Dispose(disposing);
    
            inDispose = false;
    
        }
    }
