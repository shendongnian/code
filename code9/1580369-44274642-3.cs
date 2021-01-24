    MassTransit.Serialization.MessageEnvelope envelope;
    
    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
    using (Stream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
    using (BsonReader jsonReader = new Newtonsoft.Json.Bson.BsonReader(csDecrypt))
    {
    	envelope = _deserializer.Deserialize<MessageEnvelope>(jsonReader);
    }
    
    string output = JsonConvert.SerializeObject(envelope, Newtonsoft.Json.Formatting.Indented);
    return output;
