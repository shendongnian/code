    public void CreateOrgStructure(string path = "/Test/TestData.json"){
            string DataFilePath = AppContext.BaseDirectory + path;
            JObject json = JObject.Parse(File.ReadAllText(DataFilePath));
            foreach (JToken OrgToken in json["Orgs"])
    			{
                    Debug.WriteLine("Org "+OrgToken["Name"]);
    				Org o = OrgToken.ToObject<Org>();
    				_cont.Orgs.Add(o);
                    _cont.SaveChanges();
            }
    }
