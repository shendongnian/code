	 using System.Text.RegularExpressions;
	 ...
		string pattern = @"xmlns=""[a-zA-Z0-9:\/._]{1,}""";
		using (StringWriter stringwriter = new System.IO.StringWriter())
		{
			XmlSerializer ser = new XmlSerializer(typeof(QualityDeviationCaseType));
			ser.Serialize(stringwriter, oQualityDeviationCaseType);
			string s = stringwriter.ToString();
			Match m = Regex.Match(s,pattern);
			if(m.Success)
			   s=s.Replace(m.Value, "");
		
		
			sampleChannel.Publish(s);
			//This line of code sending my xml file to IBM WMQ.
		}
