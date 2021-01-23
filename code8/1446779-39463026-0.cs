    var assembly = Assembly.GetExecutingAssembly();
    			const string resourceName = "MyCompany.MyProduct.MyFile.txt";
    			using (var stream = assembly.GetManifestResourceStream(resourceName))
    			{
    				if (stream != null)
    					using (var reader = new StreamReader(stream))
    					{
    						var result = reader.ReadToEnd();
    						// Find username and password
    					}
    			}
