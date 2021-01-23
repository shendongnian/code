    public static void Serialize(object obj, FileInfo destination)
    {
    	if (null != obj)
    	{
    		using (TextWriter writer = new StreamWriter(destination.FullName, false))
    		{
    			XmlTextWriter xmlWriter = null;
    			try
    			{
    				xmlWriter = new XmlTextWriter(writer);
    				DataContractSerializer formatter = new DataContractSerializer(obj.GetType());
    				formatter.WriteObject(xmlWriter, obj);
    			}
    			finally
    			{
    				if (xmlWriter != null)
    				{
    					xmlWriter.Flush();
    					xmlWriter.Close();
    				}
    			}
    		}
    	}
    }
