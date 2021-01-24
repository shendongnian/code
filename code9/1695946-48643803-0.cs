	public interface SAPI
	{
		SqlConnection dbConnection { get; }
		void ServiceAPI();
		void CreateNewAccount(string Name, string userName, string password, string PhoneNumber, string CNIC);
	}
