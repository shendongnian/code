    public static Customer GetCustomerByID(int id)
    {
    	try
    	{
    		using (var client = GetConfiguredClient())
    		{
    			var requestUri = $"Customers/{id}";
                Customer customer;
    			using (var response = client.GetAsync(requestUri).Result)
    			{
    				try 
    				{
    					response.EnsureSuccessStatusCode();
    					// If we reach here it means we can get the customer data.
    					customer = response.Content.ReadAsAsync<Customer>().Result;
    				}
    				catch(HttpRequestException)
    				{
    					if(response.StatusCode == HttpStatusCode.NotFound) // 404
    					{
    						customer = null;
    					}
    					else
    					{
    						throw;
    					}
    				}
    			}
    
    			return customer;
    		}
    	}
    	catch (Exception ex)
    	{
    		ex.Data.Add(nameof(id), id);
    
    		LogException(ex);
    
    		throw;
    	}
    }
