    public static class ExcelChartExtensions
    {
    	/// <summary>
    	/// Whether to show Rounded Corners or not for the border of the Excel Chart.
    	/// </summary>
    	public static void ShowRoundedCorners(this ExcelChart chart, bool show)
    	{
    		XmlElement roundedCornersElement = (XmlElement)chart.ChartXml.SelectSingleNode("c:chartSpace/c:roundedCorners", chart.WorkSheet.Drawings.NameSpaceManager);
    
    		if (roundedCornersElement == null)
    		{
    			XmlElement chartSpaceElement = chart.ChartXml["c:chartSpace"];
    			roundedCornersElement = chart.ChartXml.CreateElement("c:roundedCorners", chartSpaceElement.NamespaceURI);
    			chartSpaceElement.AppendChild(roundedCornersElement);
    		}
    
    		roundedCornersElement.SetAttribute("val", Convert.ToInt32(show).ToString());
    	}
    }
