	public static void SetLineChartColor(this ExcelChart chart, int serieIdx, int chartSeriesIndex, Color color)
	{
		var chartXml = chart.ChartXml;
		var nsa = chart.WorkSheet.Drawings.NameSpaceManager.LookupNamespace("a");
		var nsuri = chartXml.DocumentElement.NamespaceURI;
		var nsm = new XmlNamespaceManager(chartXml.NameTable);
		nsm.AddNamespace("a", nsa);
		nsm.AddNamespace("c", nsuri);
		var serieNode = chart.ChartXml.SelectSingleNode($@"c:chartSpace/c:chart/c:plotArea/c:lineChart/c:ser[c:idx[@val='{serieIdx}']]", nsm);
		var serie = chart.Series[chartSeriesIndex];
		var points = serie.Series.Length;
		//Add reference to the color for the legend
		var srgbClr = chartXml.CreateNode(XmlNodeType.Element, "srgbClr", nsa);
		var att = chartXml.CreateAttribute("val");
		att.Value = $"{color.R:X2}{color.G:X2}{color.B:X2}";
		srgbClr.Attributes.Append(att);
		var solidFill = chartXml.CreateNode(XmlNodeType.Element, "solidFill", nsa);
		solidFill.AppendChild(srgbClr);
		var ln = chartXml.CreateNode(XmlNodeType.Element, "ln", nsa);
		ln.AppendChild(solidFill);
		var spPr = chartXml.CreateNode(XmlNodeType.Element, "spPr", nsuri);
		spPr.AppendChild(ln);
		serieNode.AppendChild(spPr);
	}
