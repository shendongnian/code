    string stringToSend = "Hello man";
    BinaryWriter writer = new BinaryWriter(mClientSocket.GetStream(),Encoding.UTF8);
    //write number of bytes: Original line was sending the entire string here. Optionally if you string is longer than 255 characters, you'll need to send another data type, perhaps an integer converted to 4 bytes.
    byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(stringToSend);
    mClientSocket.GetStream().Write((byte)textBytes.Length);
    //write text the entire buffer
  
    writer.Write(textBytes, 0, textBytes.Length);
