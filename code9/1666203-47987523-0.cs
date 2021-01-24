    byte[] sigbytes = Convert.FromBase64String(xmlDoc.SelectSingleNode("//Pkcs7Resp").InnerText);
    byte[] paddedSig = new byte[8192];
    Array.Copy(sigbytes, 0, paddedSig, 0, sigbytes.Length);
    PdfDictionary dic2 = new PdfDictionary();
    dic2.Put(PdfName.CONTENTS, new PdfString(paddedSig).SetHexWriting(true));
    appearance.Close(dic2);
