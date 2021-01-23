		namespace Testing.Pages
		{
			public enum Themes
			{
				Light = 1,
				Dark = 2
			}
		}
		namespace Testing.Pages
		{
			public class ThemeSettingNotFoundException : Exception
			{
				public ThemeSettingNotFoundException() : base("error, nothing found")
				{
				}
			}
		}
		namespace Testing.Pages
		{
			class BindingClass : INotifyPropertyChanged
			{
				private string _setting;
				public event PropertyChangedEventHandler PropertyChanged;
				public BindingClass() {
				}
				public BindingClass(string value) {
					_setting = value;
				}
				public string SettingProperty
				{
					get { return _setting; }
					set
					{
                        if(!_setting.Equals(value)){
						    _setting = value;
						    OnPropertyChanged(value);
                        }
					}
				}
				protected void OnPropertyChanged([CallerMemberName] string _setting = "") {
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(_setting));
				}
			}
		}
		namespace Testing.Pages
		{
			/// <summary>
			/// An empty page that can be used on its own or navigated to within a Frame.
			/// </summary>
			public sealed partial class SettingsPage : Page
			{
				BindingClass notifyProperty = new BindingClass();
				public SettingsPage() {
					this.InitializeComponent();
					NavigationCacheMode = NavigationCacheMode.Enabled;
					//Subscribe to the PropertyChanged event
					notifyProperty.PropertyChanged += OnThemeSettingChanged;
				}
				private void ChangeTheme_btn_Click(object sender, RoutedEventArgs e) {
					DataContext = notifyProperty;
					SaveThemeSettings();
				}
				private void SaveThemeSettings()
				{
					var notifySettings = 0;
					if ((bool)DarkTheme_btn.IsChecked)
						notifySettings = 2;
					else if ((bool)LightTheme_btn.IsChecked)
						notifySettings = 1;
					//Only save theme settings when a button was checked
					if (notifySettings != 0)
						AppSettings.saveThemeSettings((Themes)notifySettings);
				}
				private void OnThemeSettingChanged(object sender, PropertyChangedEventArgs args)
				{
					PopupText.Visibility = Visibility.Visible;
					popup_animate.Begin();
				}
			}
		}
		namespace Testing.Pages
		{
			class AppSettings
			{
				private const string ThemeSettingKey = "AppThemeSetting";
				public static void saveThemeSettings(Themes theme) {
					ApplicationDataContainer themeSettings = ApplicationData.Current.LocalSettings;
					themeSettings.Values[ThemeSettingKey] = theme.ToString();
				}
				public static Themes readThemeSettings() {
					ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
					if (!localSettings.Values.ContainsKey(ThemeSettingKey))
						throw new ThemeSettingNotFoundException();
					var appSettingsString = localSettings.Values[ThemeSettingKey];
					return (Themes)Enum.Parse(typeof(Themes), appSettingsString);
				}
				public static void removeLocalSettings(string settingValue) {
					ApplicationData.Current.LocalSettings.Values.Remove(settingValue);
				}
			}
		}
