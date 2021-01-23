    string zHex = (zBackInHex.Replace("-", "");
    byte[] ba = new byte[zHex.Length / 2];  //One byte for each two chars in zHex
    for(int ZZ = 0; ZZ < ba.Length; ZZ++){
       ba[ZZ] = Convert.ToByte(zHex.Substring(ZZ * 2, 2), 16);
    }
    string zBackIn = Encoding.ASCII.GetString(ba);  //The original string
