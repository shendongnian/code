	// we receive a hash that needs to be signed
	Stream istream = response.GetResponseStream();
	MemoryStream baos = new MemoryStream();
	data = new byte[0x100];
	while ((read = istream.Read(data, 0, data.Length)) != 0)  
		baos.Write(data, 0, read);  
	istream.Close();
	byte[] hash = baos.ToArray();
	
	// we load our private key from the key store
	Pkcs12Store store = new Pkcs12Store(new FileStream(KEYSTORE, FileMode.Open), PASSWORD);
	String alias = "";
	// searching for private key
	foreach (string al in store.Aliases)
		if (store.IsKeyEntry(al) && store.GetKey(al).Key.IsPrivate) {
			alias = al;
			break;
		}
	AsymmetricKeyEntry pk = store.GetKey(alias);
	// we sign the hash received from the server
	ISigner sig = SignerUtilities.GetSigner("SHA256withRSA");
	sig.Init(true, pk.Key);
	sig.BlockUpdate(hash, 0, hash.Length);
	data = sig.GenerateSignature();
	
	// we make a connection to the PostSign Servlet
	request = (HttpWebRequest)WebRequest.Create(POST);
	request.Headers.Add(HttpRequestHeader.Cookie,cookies.Split(";".ToCharArray(), 2)[0]);
	request.Method = "POST";
	// we upload the signed bytes
	os = request.GetRequestStream();
	os.Write(data, 0, data.Length);
	os.Flush();
	os.Close();
