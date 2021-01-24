    Aes aes = Aes.Create();
    aes.Key = yourByteArrayKey;
    aes.IV = yourByteArrayIV;
    
    // Save
    using (FileStream fs = new FileStream(fileName, FileMode.Create)) {
    	using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write)) {
    		new BinaryFormatter().Serialize(cs, myObject);
    	}
    }
    
    // Load
    using (FileStream fs = new FileStream(fileName, FileMode.Open)) {
    	using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Read)) {
    		myObject = (Templates)new BinaryFormatter().Deserialize(cs);
    	}
    }
