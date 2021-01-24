       var token = HardwareIdentification.GetPackageSpecificToken(null);
       using (DataReader reader = DataReader.FromBuffer(token.Id))
       {
           byte[] bytes = new byte[token.Id.Length];
           reader.ReadBytes(bytes);
           string uniqueCode = Encoding.ASCII.GetString(bytes);
       }
