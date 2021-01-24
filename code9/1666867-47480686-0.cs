    public static void Main()
	{
		var url = "http://w1.lara.state.mi.us/ChildCareSearch/Home/SearchResults";
		using(WebClient client = new WebClient())
		{
    		var reqparm = new System.Collections.Specialized.NameValueCollection
			{
				{"pq_datatype", "JSON"}, {"pq_curpage", "1"}, {"pq_rpp", "10"}
			};
    		var responsebytes = client.UploadValues(url, "POST", reqparm);
    		var json = Encoding.UTF8.GetString(responsebytes);
			var root = JsonConvert.DeserializeObject<RootObject>(json);
			var name = TrimAnchor(root.Data[0].CdcName);
			Console.WriteLine(name);
		}
	}
	
	public static string TrimAnchor(string node)
	{
		return node.Substring(node.IndexOf('>') + 1).Replace("</a>","");
	}
    public class Datum
    {
        public string CdcLicNbr { get; set; }
        public string CdcName { get; set; }
        public string CdcAddr { get; set; }
        public string CdcCity { get; set; }
        public string CdcZip { get; set; }
        public string CdcLicName { get; set; }
        public string CdcType { get; set; }
        public int CdcCnty { get; set; }
        public string CntyDesc { get; set; }
        public string FacilityType { get; set; }
    }
    public class RootObject
    {
        public List<Datum> Data { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
    }
