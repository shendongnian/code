    public string GetApnsToken(string authKeyPath,  
    Dictionary<string, object> payload, 
    Dictionary<string, object> header)
    {
        ECPrivateKeyParameters ecPrivateKeyParameters;
        using (var reader = new StreamReader(new FileStream(authKeyPath, FileMode.Open, FileAccess.Read, FileShare.Read)))
        {
           ecPrivateKeyParameters = (ECPrivateKeyParameters)new PemReader(reader).ReadObject();
         }
         byte[] headerBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(header));
         byte[] payloadBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));
         byte[] bytesToSign = Encoding.UTF8.GetBytes(ConcatTokenPartsWithEncoding(headerBytes, payloadBytes));
                
       var signer = new DsaDigestSigner(new ECDsaSigner(), new Sha256Digest());
       signer.Init(true, ecPrivateKeyParameters);
       signer.BlockUpdate(bytesToSign, 0, bytesToSign.Length);
       byte[] signBytes = signer.GenerateSignature();
            
       return ConcatTokenPartsWithEncoding(headerBytes, payloadBytes, signBytes);
            
    }
            
    public static string ConcatTokenPartsWithEncoding(params byte[][] parts)
    {
    var builder = new StringBuilder();
    foreach (var part in parts)
    {
     //encode base64 for Url
     var base64Str = Convert.ToBase64String(part);
     base64Str = base64Str.Split('=')[0]; // Remove any trailing '='s
     base64Str = base64Str.Replace('+', '-'); 
     base64Str = base64Str.Replace('/', '_');
     builder.Append(base64Str).Append(".");
    }
    builder.Remove(builder.Length - 1, 1); 
    return builder.ToString();
    }
