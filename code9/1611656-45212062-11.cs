    public abstract class BaseCalibrationToolsLoader : ICalibrationToolsLoader
    {
        public BaseCalibrationToolsLoader()
        {
            // put here the shared constructor code
            _cmcCalibrationToolsOrder = new List<CalibrationGroup>
            {
                CalibrationGroup.GeneralDataTools,
                CalibrationGroup.SensorAndModuleSettingsTools,
                CalibrationGroup.LateralChromaticAberrationTool,
            };
        }
        public List<CalibrationGroup> GetCmcGroupOrder()
        {
            // Put here the shared code among the two implementation
        }
        // As the implementation is different, you declare the method abstract so you only implement it in the concret classes
        public abstract string GetDefaultIspFile(string selectedSensorType = null);
    }
