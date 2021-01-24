    List<byte[]> d = new List<byte[]>();
    foreach (var item in IDs)
    { 
        obj = RequisitionsObj.GenerateLabOrderReq();
        if (obj.Data != null)
        {    
            d.Add(obj.Data);
        }
    
    }
    
    byte[] final = d.SelectMany(a => a).ToArray();
