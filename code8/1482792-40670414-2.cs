    List<string> address = new List<string>();
    address.Add(ds.Tables[0].Rows[0]["PhysicalAddressLine1"].ToString());
    address.Add(ds.Tables[0].Rows[0]["PhysicalAddressLine2"].ToString());
    address.Add(ds.Tables[0].Rows[0]["PhysicalAddressCity"].ToString());
    address.Add(ds.Tables[0].Rows[0]["JurisdictionX"].ToString());
    address.Add(ds.Tables[0].Rows[0]["PhysicalAddressPin"].ToString());
    
    string list = string.Join(", ", address.Where(x => !string.IsNullOrEmpty(x)));
