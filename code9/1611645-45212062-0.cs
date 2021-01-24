    public abstract class BaseCalibrationToolsLoader : ICalibrationToolsLoader
    {
        public BaseCalibrationToolsLoader()
        {
            // put here the shared constructor code
        }
        public void SharedMethod()
        {
            // One method where the code is shared among the two implementation
        }
        // As the implementation is different, you declare the method abstract so you only implement it in the concret classes
        public abstract void GetDefaultIsp();
    }
