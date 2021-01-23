    public class ProductRepository : IProductRepository
    {
        //initializing (1,1) will allow only 1 use of the object
    	static SemaphoreSlim semaphoreLock = new SemaphoreSlim(1, 1);
    	public async Task<IProductData> GetProductDataByIdAsync(int productId)
    	{
    		try
    		{
    			//if semaphore is in use, subsequent requests will wait here
    			await semaphoreLock.WaitAsync();
    			try
    			{
    				using (var client = new HttpClient())
    				{
    					client.BaseAddress = new Uri("yourbaseurl");
    					client.DefaultRequestHeaders.Accept.Clear();
    					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    					string url = "yourendpoint";
    					HttpResponseMessage response = await client.GetAsync(url);
    					if (response.IsSuccessStatusCode)
    					{
    						var json = await response.Content.ReadAsStringAsync();
    						ProductData prodData = JsonConvert.DeserializeObject<ProductData>(json);
    						return prodData;
    					}
    					else
    					{
    						//handle non-success
    					}
    				}
    			}
    			catch (Exception e)
    			{
    				//handle exception
    			}
    		}
    		finally
    		{
    			//if any requests queued up, the next one will fire here
    			semaphoreLock.Release();
    		}
    	}
    }
