    public enum SwipeDeriction
    {
        Left = 0,
        Rigth,
        Above,
        Bottom
    }
    
    public class SwipeGestureReconginzer : PanGestureRecognizer
    {
        public delegate void SwipeRequedt(object sender, SwipeDerrictionEventArgs e);
    
        public event EventHandler<SwipeDerrictionEventArgs> Swiped;
    
        public SwipeGestureReconginzer()
        {
            this.PanUpdated += SwipeGestureReconginzer_PanUpdated;
        }
    
        private void SwipeGestureReconginzer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.TotalY > -5 | e.TotalY < 5)
            {
                if (e.TotalX > 10)
                {
                    Swiped(this, new SwipeDerrictionEventArgs(SwipeDeriction.Rigth));
                }
                if (e.TotalX < -10)
                {
                    Swiped(this, new SwipeDerrictionEventArgs(SwipeDeriction.Left));
                }
            }
    
            if (e.TotalX > -5 | e.TotalX < 5)
            {
                if (e.TotalY > 10)
                {
                    Swiped(this, new SwipeDerrictionEventArgs(SwipeDeriction.Bottom));
                }
                if (e.TotalY < -10)
                {
                    Swiped(this, new SwipeDerrictionEventArgs(SwipeDeriction.Above));
                }
            }
        }
    }
    
    public class SwipeDerrictionEventArgs : EventArgs
    {
        public SwipeDeriction Deriction { get; }
    
        public SwipeDerrictionEventArgs(SwipeDeriction deriction)
        {
            Deriction = deriction;
        }
    }
