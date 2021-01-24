    public class Temperature
    {
        public Surface this[double time]
        {
            get { return GetSurfaceObjectForGivenTime(time); }
        }
    }
