    long centuryBegin = new DateTime(2001, 1, 1).Ticks; 
    // 631139040000000000
    
    long currentDate = DateTime.Now.Ticks;
    // 636082790310018373
    
    long shortTicks = (currentDate - centuryBegin) / 100L;
    // 49437503100183
    
    string base64Ticks = Convert.ToBase64String(BitConverter.GetBytes(shortTicks)).Substring(0, 8);
    // F5XPkPYs
    
    byte[] data = new byte[8];
    Convert.FromBase64String(base64Ticks + "AAA=").CopyTo(data, 0);
    long originalTicks = (BitConverter.ToInt64(data, 0) * 100L) + centuryBegin;
    // 636082790310018300
