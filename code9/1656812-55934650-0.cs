 lang-xaml
<Label Content="{Binding Path=Strings.ErrorLevelColumnHeaderLabel}"/>
Of course the `Strings` object must be accessible from all datacontexts.
The strings are stored in a database table that looks like this, an ID-column and one column for each of the supported languages:
    ID  en        da        de
    24  'Level'   'Niveau'  'Stufe'
I created a `UIStringsVM` class which implements the `INotifyPropertyChanged` interface. In my example I have implemented this in a base class called `Observable`, which I am sure many others have as well. [See this answer for details][1].
 lang-cs
public class UIStringsVM : Observable
{
	public static UIStringsVM CurrentStringsInstance;
	private bool stringsAreLoading = false;
	private Dictionary<int, string> stringDictionary;
}
The `UIStringsVM` class have a property for each string I need to have localized. Since the class supports the `INotifyPropertyChanged` interface through the base class I can then rely on changes to be reflected in the UI when ever the language changes.
Inside the `UIStringsVM` class the strings for the current language is stored in a `Dictionary<int, string>`. The reason for this is that I can use the string ID from the database to access the correct string.
Now I can use the ID inside the property Get method to return whatever string is stored for that value. So the properties will look like this:
 lang-cs
public string ErrorLevelColumnHeaderLabel
{
	get =>
		this.stringDictionary[24].Replace("\\n", Environment.NewLine);
	private set =>
		this.stringDictionary[24] = value;
}
The properties are never set individually so the setter could be omitted. 
The constructor:
 lang-cs
public UIStringsVM()
{
	this.stringDictionary = new Dictionary<int, string>();
	// Initialize with default values. The ! at the end makes it easier to identify missing values in the database. 
	this.LoginButtonText = "Login!";
	this.LogoutButtonText = "Logout!";
	this.UserLabelFormatString = "{0} logged in!";
	this.ErrorLevelColumnHeaderLabel = "Level!";
	UIStringsVM.CurrentStringsInstance = this;
}
In order to load the strings I use the following method:
 lang-cs
public async Task LoadStringsAsync(string languageCode, CancellationToken ct)
{
	if (languageCode.Length != 2)
		throw new ArgumentException("languageCode must be exactly 2 characters.", nameof(languageCode));
	this.StringsAreLoading = true;
	var client = new UIStringsClient(AppVM.BaseURL);
	try
	{
		var apiStrings = await client.GetByLanguageAsync(languageCode, ct);
		foreach (var r in apiStrings)
		{
			/* Note: this will make it impossible to overwrite a string with an empty string from the database, 
			 * thus always keeping the string defined in this class' constructor. However strings will always 
			 * have a value as defined in the constructor even if one does not exist in the database.
			 * */
			if (string.IsNullOrWhiteSpace(r.Value))
				continue;
			this.stringDictionary[r.Key] = r.Value;
		}
		this.OnPropertyChanged((string)null); // Raise a change event for the entire object, not just a named property
	}
	finally
	{
		this.StringsAreLoading = false;
	}
}
I hope this helps anyone who might happen to come across this late answer. I have been running this solution for 15 months or so, and its been really great to work with. 
  [1]: https://stackoverflow.com/a/35582811/3631673
