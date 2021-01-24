    using (Stream cs = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyProj.MyCert.cer"))
    {
        Byte[] raw = new Bbyte[cs.Length];
        for (Int32 i = 0; i < cs.Length; ++i)
            raw[i] = (Byte)cs.ReadByte();
        X509Certificate2 cert = new X509Certificate2();
        cert.Import(raw);
        // Do whatever you need...
    }
