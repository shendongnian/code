                var sr_no = "";
                var data =new List<Data>();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                axCZKEM1.EnableDevice(iMachineNumber, false);
                Cursor = Cursors.WaitCursor;
                axCZKEM1.ReadAllUserID(iMachineNumber);//read all the user information to the memory
                axCZKEM1.ReadAllTemplate(iMachineNumber);//read all the users' fingerprint templates to the memory
                while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))//get all the users' information from the memory
                {
                    for (idwFingerIndex = 0, i = 0; idwFingerIndex < 10; idwFingerIndex++, i++)
                    {
                        if (axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))//get the corresponding templates string and length from the memory
                        {
    
                            data.Add(new Data { code = sdwEnrollNumber, findex = idwFingerIndex.ToString() });
                            i++;
                        }
                    }
                }
    
                var postObject = new RootObject
                {
                    sr_no = sr_no,
                    data = data
                };
                var postData = jss.Serialize(postObject);
    
    public class Data
    {
        public string code { get; set; }
        public string findex { get; set; }
    }
    
    public class RootObject
    {
        public string sr_no { get; set; }
        public List<Data> data { get; set; }
    }
