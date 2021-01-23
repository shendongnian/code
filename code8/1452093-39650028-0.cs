	public void DeleteSecureValue(string appName, string key)
	{
		var store = AccountStore.Create();
		var account = AccountStore.Create().FindAccountsForService(appName).FirstOrDefault();
		if (account.Properties.ContainsKey(key))
		{
			account.Properties.Remove(key);
			store.Save(account, appName);
		}
	}
