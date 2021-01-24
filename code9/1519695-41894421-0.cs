     var headersToSign = new[] { HeaderId.From, HeaderId.To, HeaderId.Subject, HeaderId.ReplyTo, HeaderId.MimeVersion, HeaderId.ContentType };
                    int HeaderIndex = message.Headers.IndexOf("X-Mailer");
                    if (HeaderIndex > -1)
                    {
                        Header MyHeader = message.Headers[HeaderIndex]; 
                        var  sng = MyHeader.Id;
                        int currentsize = headersToSign.Length;
                        Array.Resize(ref headersToSign, currentsize +1 );
                        headersToSign[currentsize] = sng;
                    }
                    var signer = new DkimSigner(s, "mydomain.com", "myd");   
                    message.Sign(signer, headersToSign, DkimCanonicalizationAlgorithm.Relaxed, DkimCanonicalizationAlgorithm.Relaxed);
