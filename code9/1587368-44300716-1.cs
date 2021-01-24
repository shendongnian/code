    using Newtonsoft.Json;
    string jsonString = "{\"ALC\":\"FSC\",\"AVS\":\"7\",\"CAB\":\"M\",\"CL\":\"W\",\"CNF\":\"N\",\"CNX\":\"N\",\"DES\":\"DEL\",\"DTE\":\"3\",\"EDT\":\"29 Jun 2017 09:20\",\"FBAG\":\"15 Kg\",\"FBC\":\"W2IPO\",\"FCUR\":null,\"FN\":\"9W 822\",\"FQT\":true,\"FRI\":\"FSC0\",\"FYT\":\"160\",\"ITN\":\"0\",\"JYT\":\"160\",\"MCL\":\"0\",\"OFF\":0,\"OFI\":false,\"OFR\":null,\"ORG\":\"MAA\",\"PC\":\"9W\",\"RBD\":null,\"RFN\":\"False\",\"RTK\":\"TAX:1801ASPLIT2901ASPLIT1101ASPLITADT1ASPLIT\",\"SDT\":\"29 Jun 2017 06:40\",\"SGD\":\"Aircraft Type : 738\u000d\u000aJourney Time : 160\u000d\u000aStart Terminal : 1\u000d\u000aEndTerminal : 3\u000d\u000aBaggage : 15 Kg\",\"SGR\":\"\",\"STE\":\"1\",\"STP\":\"0\",\"TNF\":false,\"VIA\":\"\",\"VIAITN\":null}";
    
    Dictionary<string, string> dict = new Dictionary<string, string>();
                
    dict = JsonConvert.DeserializeObject <Dictionary<string, string>>(jsonString);
    var list = dict.ToList(); 
