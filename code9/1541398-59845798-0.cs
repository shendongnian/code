	public partial class App : Application
	{
		static App()
		{
			FrameworkElement.LanguageProperty.OverrideMetadata(
				typeof(FrameworkElement),
				new FrameworkPropertyMetadata(
					XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
		}
	}
