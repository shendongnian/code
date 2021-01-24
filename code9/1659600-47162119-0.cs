    public class DataSetExcel : DataSet
    {
    	public DataSetExcel(string dataSetName) : base()
        {
    	    this.DataSetName = dataSetName;
    	}
    	public string GetXMLSchema()
    	{
            string result = base.GetXmlSchema();
    	    result = result.Replace("xs:choice", "xs:sequence");
    	    return result;
    	}
    }
