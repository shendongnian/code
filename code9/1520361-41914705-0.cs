    public abstract class MovingObjectsController
    {
        protected abstract MovingObjectsData Data { get; }
    }
    public class PlatformController : MovingObjectsController
    {
        private MovingObjectsData data;
        public PlatformController()
        {
            this.data = new MovingObjectsData(); //This being whatever data is specific to this object
        }
        protected override MovingObjectsData Data { 
            get 
            {
                return data; 
            }
        }
    }
