    private byte[] signPDF(byte[] pk)
        {
    
            byte[] paddedSig = new byte[csize];
            System.Array.Copy(pk, 0, paddedSig, 0, pk.Length);
    
            PdfDictionary dic2 = new PdfDictionary();
            dic2.Put(PdfName.CONTENTS, new PdfString(paddedSig).SetHexWriting(true));
            appearance.Close(dic2);
    
            //System.IO.File.WriteAllBytes(System.Web.HttpContext.Current.Server.MapPath("~/temp.pdf"), ms.ToArray());
            return ms.ToArray();
    
        }
