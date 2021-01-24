    RootObject obj = new RootObject();
    obj.sr_no = "OH009876673";
    obj.data = new List<Datum>();
    ......
    ......
    while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
    {
        for (idwFingerIndex = 0,i=0; idwFingerIndex < 10; idwFingerIndex++,i++)
        {
            if (axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))//get the corresponding templates string and length from the memory
            {
    
                //var obj = new Dictionary<string, string>();
                //obj["code"] = sdwEnrollNumber;
                //obj["findex"] = idwFingerIndex.ToString();
                //data[i] = jss.Serialize(obj);
                //i++;
                obj.data.Add( new Datum() {code = sdwEnrollNumber, findex = idwFingerIndex.ToString()});
            }
        }
    }
    
    axCZKEM1.EnableDevice(iMachineNumber, true);
    
    var client = new RestClient();
    client.EndPoint = @"";
    
    var outputJson = JsonConvert.SerializeObject(obj);
