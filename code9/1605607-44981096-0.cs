    string stringToSend = "Hello man";
    BinaryWriter writer = new BinaryWriter(mClientSocket.GetStream(),Encoding.UTF8);
    //write number of bytes: Original line was sending the entire string here.
    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(stringToSend);
    mClientSocket.GetStream().Write((byte)textBytes.Length);
    //write text the entire buffer
  
    writer.Write(textBytes, 0, textBytes.Length);
