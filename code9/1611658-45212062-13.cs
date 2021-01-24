    public abstract class BaseCalibrationToolsLoader : ICalibrationToolsLoader
    {
        [..]
        // By using the virtual keyword, you allow your method to be overriden in the derived classes
        public virtual void PartiallySharedMethod()
        {
            // Shared implementation
        }
        [..]
    }
