	public class DataProtectorTokenProvider : DataProtectorTokenProvider<User>
	{
		public DataProtectorTokenProvider(IDataProtectionProvider dataProtectionProvider) : base(dataProtectionProvider.Create("ASP.NET Identity"))
		{
			TokenLifespan = TimeSpan.FromHours(6);
		}
	}
