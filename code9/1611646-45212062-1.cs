    public class Ipu4CalibraitionToolsLoader : BaseCalibrationToolsLoader 
    {
        public Ipu4CalibraitionToolsLoader ()
            : base() // <- call the protected constructor
        {
            // put here the specific implementation constructor code
            // notice that the constructor of the abstract class will be call before this code
        }
        // The SharedMethod is already implemented, nothing to do about it
        public override void GetDefaultIsp()
        {
            // put here the concrete implementation for Ipu4
        }
    }
    public class Ipu6CalibraitionToolsLoader: BaseCalibrationToolsLoader 
    {
        public Ipu6CalibraitionToolsLoader()
            : base() // <- call the protected constructor
        {
            // put here the specific implementation constructor code
            // notice that the constructor of the abstract class will be call before this code
        }
        // The SharedMethod is already implemented, nothing to do about it
        public override void GetDefaultIsp()
        {
            // put here the concrete implementation for Ipu6
        }
    }
