	public class Program
	{
		public static void Main()
		{
			var settings = new DerivedSettings()
			{Name = "John"};
			DerivedPlugin a = new DerivedPlugin(settings);
			IPlugin<BaseSettings> sample = (IPlugin<BaseSettings>)a;
			Console.WriteLine(sample.GetName());
		}
	}
	
	public abstract class BaseSettings
	{
		public abstract string Name
		{
			get;
			set;
		}
	}
	
	public interface IPlugin<out TSettings>
		where TSettings : BaseSettings
	{
		string GetName();
	}
	
	public abstract class BasePlugin<TSettings> : IPlugin<TSettings> where TSettings : BaseSettings
	{
		protected readonly TSettings _settings;
		public BasePlugin(TSettings settings)
		{
			_settings = settings;
		}
	
		public virtual string GetName()
		{
			return _settings.Name;
		}
	}
	
	public class DerivedSettings : BaseSettings
	{
		public override string Name
		{
			get;
			set;
		}
	}
	
	public class DerivedPlugin : BasePlugin<DerivedSettings>
	{
		public DerivedPlugin(DerivedSettings settings): base (settings)
		{
		}
	}
