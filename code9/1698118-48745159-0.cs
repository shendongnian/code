    public byte[] HtmlToDoc(string hmtl, string userId)
    {
    	byte[] data;
        //Add using statement here and wrap it around the rest of the code
    	using(var auditor = new ServiceAuditor { User = userId })
    	{
    		try
    		{
    			using (var tx = new ServerText())
    			{
    				tx.Create();
    				tx.Load(Server.HtmlDecode(hmtl), StringStreamType.HTMLFormat);
    				tx.Save(out data, BinaryStreamType.MSWord);
    			}
    		}
    		catch (Exception e)
    		{
    			auditor.Errormessage = e.Message + "/n " + e.StackTrace;
    			data = new byte[0];
    		}
    		finally
    		{
    			auditor.Save();
                //No need to manually dispose here any more
    		}
    	}
    
    	return data;
    }
