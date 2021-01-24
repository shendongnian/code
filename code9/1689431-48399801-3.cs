    byte[] IV = new byte[16];
    byte[] Encoded = new byte[inputAsByteArray.Length - IV.Length];
    Array.Copy(inputAsByteArray, 0, IV, 0, IV.Length);
    Array.Copy(inputAsByteArray, IV.Length, Encoded, 0, Encoded.Length);
    
    //later in your code....
    //Encoding = the data you are going to decrypt.  
    aesAlg.IV = IV;
