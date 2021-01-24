    public class Ipu4CalibraitionToolsLoader : BaseCalibrationToolsLoader 
    {
        public Ipu4CalibraitionToolsLoader ()
            : base() // <- call the protected constructor
        {
            // put here the specific implementation constructor code
            // notice that the constructor of the abstract class will **ALWAYS** be call before this code
            _ispSectionUiSettings = Serialization.DataContract.Deserialize<IspSectionUiSettings>(GetDefaultIspFile());
        }
        // The GetCmcGroupOrder is already implemented, nothing to do about it
        // With the sealed keyword, the method cannot be overriden in another class
        public sealed override void GetDefaultIsp(string selectedSensorType = null)
        {
            // put here the concrete implementation for Ipu4
        }
    }
    public class Ipu6CalibraitionToolsLoader: BaseCalibrationToolsLoader 
    {
        public Ipu6CalibraitionToolsLoader(string selectedSensorType)
            : base() // <- call the protected constructor
        {
            // put here the specific implementation constructor code
            // notice that the constructor of the abstract class will **ALWAYS** be call before this code
            _selectedSensorType = selectedSensorType;
            _ispSectionUiSettings = Serialization.DataContract.Deserialize<IspSectionUiSettings>(GetDefaultIspFile(_selectedSensorType));
        }
        // The GetCmcGroupOrder is already implemented, nothing to do about it
        // With the sealed keyword, the method cannot be overriden in another class
        public sealed override void GetDefaultIsp(string selectedSensorType = null)
        {
            // put here the concrete implementation for Ipu6
        }
    }
