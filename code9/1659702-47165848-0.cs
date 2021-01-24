    catch (WebException ex)
    {
    	if (ex.Response != null)
    	{ 
    		string response = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            Debug.WriteLine(response);
        }
    }
