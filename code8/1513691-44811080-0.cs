    public static class DocumentDbAccount
	{
		public static DocumentClient Parse(string connectionString)
		{
			DocumentClient ret;
			if (String.IsNullOrWhiteSpace(connectionString))
			{
				throw new ArgumentException("Connection string cannot be empty.");
			}
			if(ParseImpl(connectionString, out ret, err => { throw new FormatException(err); }))
			{
				return ret;
			}
			throw new ArgumentException($"Connection string was not able to be parsed into a document client.");
		}
		public static bool TryParse(string connectionString, out DocumentClient documentClient)
		{
			if (String.IsNullOrWhiteSpace(connectionString))
			{
				documentClient = null;
				return false;
			}
			try
			{
				return ParseImpl(connectionString, out documentClient, err => { });
			}
			catch (Exception)
			{
				documentClient = null;
				return false;
			}
		}
		private const string AccountEndpointKey = "AccountEndpoint";
		private const string AccountKeyKey = "AccountKey";
		private static readonly HashSet<string> RequireSettings = new HashSet<string>(new [] { AccountEndpointKey, AccountKeyKey }, StringComparer.OrdinalIgnoreCase);
		internal static bool ParseImpl(string connectionString, out DocumentClient documentClient, Action<string> error)
		{
			IDictionary<string, string> settings = ParseStringIntoSettings(connectionString, error);
			if (settings == null)
			{
				documentClient = null;
				return false;
			}
			if (!RequireSettings.IsSubsetOf(settings.Keys))
			{
				documentClient = null;
				return false;
			}
			documentClient = new DocumentClient(new Uri(settings[AccountEndpointKey]), settings[AccountKeyKey]);
			return true;
		}
		/// <summary>
		/// Tokenizes input and stores name value pairs.
		/// </summary>
		/// <param name="connectionString">The string to parse.</param>
		/// <param name="error">Error reporting delegate.</param>
		/// <returns>Tokenized collection.</returns>
		private static IDictionary<string, string> ParseStringIntoSettings(string connectionString, Action<string> error)
		{
			IDictionary<string, string> settings = new Dictionary<string, string>();
			string[] splitted = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
			foreach (string nameValue in splitted)
			{
				string[] splittedNameValue = nameValue.Split(new char[] { '=' }, 2);
				if (splittedNameValue.Length != 2)
				{
					error("Settings must be of the form \"name=value\".");
					return null;
				}
				if (settings.ContainsKey(splittedNameValue[0]))
				{
					error(string.Format(CultureInfo.InvariantCulture, "Duplicate setting '{0}' found.", splittedNameValue[0]));
					return null;
				}
				settings.Add(splittedNameValue[0], splittedNameValue[1]);
			}
			return settings;
		}
	}
