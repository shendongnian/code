	public interface IProductInformationsProvider
	{
		string GetProductName(int productCode);
	}
	
	public interface IConnectionStringProvider
	{
		string GetConnectionString(string shopName);
	}
	public class SQLProductInformationsProvider : IProductInformationsProvider
	{
		... 
		public SQLProductInformationsProvider(
			IConnectionStringProvider connectionStringProvider,
			ILogService logService)
		{
			...
		}
		public string GetProductName(string shopName, int productCode)
		{
			string connectionString = connectionStringProvider.GetConnectionString(shopName);
			...
		}
	}
	
	public void SearchButtonHandler(string shopName, int Code)
	{
		// _productInformationsProvider already resolved
		var productName = _productInformationsProvider.GetProductName(shopName, Code);
		// Do something with productName
	}
