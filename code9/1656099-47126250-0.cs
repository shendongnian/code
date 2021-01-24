    public class VideoPlayerViewModel : ViewModelBase
    {
        // your existing properties here, if you decide that you still need them
        
        // this could also be long/double, if you'd like to use it with your underlying type (DateTime.TotalTicks, TimeSpan.TotalSeconds, etc.)
        private uint _elapsedTime = 0; //or default(uint), whichever you prefer
        public uint ElapsedTime
        {
            get
            {
                if (_elapsedTime != value)
                {
                    _elapsedTime = value;
                    //additional "time changed" logic here, if needed
                    //if you want to skip programmatically, all you need to do is set this property!
                    OnPropertyChanged();
                }
            }
        }
        
        private double _maxTime = 0;
        public double MaxTime
        {
            // you get the idea, you'll be binding to the media's end time in whatever unit you're using (i.e. if I have a 120 second clip, this value would be 120 and my elapsed time would be hooked into an underlying TimeSpan.TotalSeconds)
        }
    }
