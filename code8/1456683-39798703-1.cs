    var dataList = new List<byte[]>();
    dataList.Add(ConvertUsTime(p.time_US));
    dataList.Add(ConvertVelocity(p.velocity));
    dataList.Add(ConvertStatus(p.status));
    
    byte[] ConvertToArray(long usTime) {
        return BitConverter.GetBytes(usTime);
    }
    
    byte[] ConvertVelocity(Int16 velocity) {
        return BitConverter.GetBytes(velocity);
    }
    
    byte[] ConvertStatus(UInt32 status) {
        return BitConverter.GetBytes(status);
    }
