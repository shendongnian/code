     // get string encoded version of body
                    using (MemoryStream ms = new MemoryStream())
                    {
                        txtTextEditor.Document.Save(RtfSerializationProvider.Instance, ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        using (StreamReader sr = new StreamReader(ms))
                        {
                            strRtfCurrBody = sr.ReadToEnd();
                        }
                    }
    // find end and then the beginning of second-to-last grouping
                    strRtfSignature = strRtfSignature.Remove(strRtfSignature.LastIndexOf('}'));
                    int intCheck = PibsEmailer.RtfFindStartpoint(strRtfSignature, strRtfSignature.LastIndexOf('}'));
                    if (intCheck < 0)
                    {
                        // this should never happen unless the content of the signature is not in valid RTF format
                        throw new Exception("AddSignature Failed. Sig=\"" + Session.CurrentUser.EmailSignature + "\" , Body=\"" + strRtfCurrBody + "\"  IntCheck=" + intCheck);
                    }
                    strRtfSignature = strRtfSignature.Substring(intCheck);
                    strRtfCurrBody = strRtfCurrBody.Insert(PibsEmailer.RtfFindLastParEnd(strRtfCurrBody), strRtfSignature);
                    byte[] byteFullContent = Encoding.ASCII.GetBytes(strRtfCurrBody);
                    using (MemoryStream ms = new MemoryStream(byteFullContent))
                    {
                        ms.Seek(0, SeekOrigin.Begin);
                        this.txtTextEditor.Selection.SelectAll();
                        this.txtTextEditor.Selection.Document.Load(RtfSerializationProvider.Instance, ms);
                    }
