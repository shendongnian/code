    List<string> businessOwners = new List<string>();
    foreach (object[] objArray in rptBusDetails) {
        foreach (object obj in objArray){
            businessOwners.Add((JToken)obj["BusinessOwner"].ToString());
        }
    }
