    ...
    int orderBitLength = privKeyParam.Parameters.N.BitLength;
    X962Parameters x962 = new X962Parameters(privKeyParam.PublicKeyParamSet);
    ECPrivateKeyStructure privKeyStruct = 
                        new ECPrivateKeyStructure(orderBitLength, privKeyParam.D, pubKeyInfo.PublicKeyData, x962);
    
    string header = @"-----BEGIN EC PRIVATE KEY-----";
    string privKeyStr = Convert.ToBase64String(privKeyStruct.GetDerEncoded(), 
                        Base64FormattingOptions.InsertLineBreaks);
    string tail = @"-----END EC PRIVATE KEY-----";
    
    string path = @"c:\tmp\myprivkey.pem";
    TextWriter textWriter = new StreamWriter(path);
    textWriter.WriteLine(header);
    textWriter.WriteLine(privKeyStr);
    textWriter.WriteLine(tail);
    textWriter.Flush();
    textWriter.Close();
    ...
