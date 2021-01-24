    // There is no need for an interface anymore (but you can keep it of course)
	public class IpuCalibrationToolsLoader
	{
		private string _selectedSensorType;
		private string _ispSectionUiSettings;
		private List<CalibrationGroup> _cmcCalibrationToolsOrder;
		public IIspFileProvider Provider { get; private set; }
        // Notice the internal constructor. No one will be able to create an instance of IpuCalibrationToolsLoader out of your assembly except the factory
		internal IpuCalibrationToolsLoader(IIspFileProvider provider, string selectedSensorType = null)
		{
			this.Provider = provider;
			_selectedSensorType = selectedSensorType;
			_ispSectionUiSettings = Serialization.DataContract.Deserialize<IspSectionUiSettings>(provider.GetDefaultIspFile(_selectedSensorType));
			this.InitCmcOrder();
		}
		public void InitCmcOrder()
		{
			_cmcCalibrationToolsOrder = new List<CalibrationGroup>
			{
				CalibrationGroup.GeneralDataTools,
				CalibrationGroup.SensorAndModuleSettingsTools,
				CalibrationGroup.LateralChromaticAberrationTool,
			};
		}
		[..] // Since the Provider is exposed as a properties of your IpuCalibrationClassLoader, there is no need for defining the GetDefaultIspFile methods within this class
	}
	public interface IIspFileProvider
	{
		string GetDefaultIspFile(string selectedSensorType = null);
	}
	public class Ipu6FileProvider : IIspFileProvider
	{
		public string GetDefaultIspFile(string selectedSensorType = null)
		{
			string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			string pathSuffix = null;
			switch ((IPU6SensorType)Enum.Parse(typeof(IPU6SensorType), selectedSensorType))
			{
				case IPU6SensorType.None:
					break;
				case IPU6SensorType.Bayer:
					pathSuffix = "IPUs\\IPU6\\IPU6DefaultsIspFile.xml";
					break;
				case IPU6SensorType.MD:
					pathSuffix = "IPUs\\IPU6\\IPU6MdDefaultsIspFile.xml";
					break;
				default:
					throw new ArgumentOutOfRangeException("selectedSensorType", selectedSensorType, null);
			}
			if (pathSuffix != null)
			{
				string path = Path.Combine(location, pathSuffix);
				return path;
			}
			throw new Exception("missing defaultIspFileXml");
		}
	}
	public class Ipu4FileProvider : IIspFileProvider
	{
		public string GetDefaultIspFile(string selectedSensorType = null)
		{
			string location = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			string pathSuffix = "IPUs\\Broxton\\IPU4DefaultsIspFile.xml";
			string path = Path.Combine(location, pathSuffix);
			return path;
		}
	}
	public static class IpuCalibrationToolsLoaderFactory
	{
		public static IpuCalibrationToolsLoader GetIpu4CalibrationToolsLoader()
		{
			return new IpuCalibrationToolsLoader(new Ipu4FileProvider());
		}
		public static IpuCalibrationToolsLoader GetIpu6CalibrationToolsLoader(string selectedSensorType)
		{
			return new IpuCalibrationToolsLoader(new Ipu6FileProvider(), selectedSensorType);
		}
	}
