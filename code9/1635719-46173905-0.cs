    //combine time and email
    byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
    byte[] key = Encoding.ASCII.GetBytes("scottrobinson@notmyemail.com);
    string encoded = Convert.ToBase64String(time.Concat(key).ToArray());
    
    //read time and email
    byte[] data = Convert.FromBase64String(encoded);
    DateTime date =  DateTime.FromBinary(BitConverter.ToInt64(data.Take(8).ToArray(), 0)); //read the date
    string email  = Encoding.Default.GetString(data.Skip(8).ToArray()); //read the email
