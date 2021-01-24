    using Google.Apis.Gmail.v1;
    using Google.Apis.Gmail.v1.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Email_Reader_Service
    {
        class SaneMessage
        {
    
            private string msID = "";
            private string msFrom = "";
            private string msDate = "";
            private string msSubject = "";
            private string msBody = "";
    
            public string ID
            {
                get { return msID; }
            }
    
            public string From
            {
                get { return msFrom; }
            }
    
            public DateTime Date
            {
                get { return Convert.ToDateTime(msDate); }
            }
    
            public string Subject
            {
                get { return msSubject; }
            }
    
            public string Body
            {
                get { return msBody; }
            }
    
            public SaneMessage(GmailService service, String userId, String messageId)
            {
                Google.Apis.Gmail.v1.Data.Message oStupidMessage = service.Users.Messages.Get(userId, messageId).Execute();
    
                string sBackupDate = string.Empty;
                foreach (var mParts in oStupidMessage.Payload.Headers)
                {
                    System.Diagnostics.Debug.Print("{0}\t\t\t\t{1}", mParts.Name, mParts.Value);
                    switch (mParts.Name)
                    {
                        case ("X-Google-Original-Date"):
                            msDate = mParts.Value;
                            break;
                        case ("Date"):
                            sBackupDate = mParts.Value;
                            break;
                        case ("From"):
                            msFrom = mParts.Value;
                            break;
                        case ("Subject"):
                            msSubject = mParts.Value;
                            break;
                    }
                }
                    
                //-----------------------------------------------------------------------------------------------
                //the fooking date comes in a plethora of formats.  if the timezone name is appended on the end
                // the datetime conversion can't convert.
                if(msDate.Length == 0)
                    msDate = sBackupDate;
                
                if (msDate.Contains('('))
                    msDate= msDate.Substring(0, msDate.LastIndexOf('('));
                //-----------------------------------------------------------------------------------------------
    
                if (msDate != "" && msFrom != "")
                {
                    string sEncodedBody;
                    if (oStupidMessage.Payload.Parts == null && oStupidMessage.Payload.Body != null)
                    {
                        sEncodedBody = oStupidMessage.Payload.Body.Data;
                    }
                    else
                    {
                        sEncodedBody = getNestedParts(oStupidMessage.Payload.Parts, "");
                    }
    
    
                    ///need to replace some characters as the data for the email's body is base64
                    msBody = DecodeURLEncodedBase64EncodedString(sEncodedBody);
    
                }
    
            }
    
            private string getNestedParts(IList<MessagePart> part, string curr)
            {
                string str = curr;
                if (part == null)
                {
                    return str;
                }
                else
                {
                    foreach (var parts in part)
                    {
                        if (parts.Parts == null)
                        {
                            if (parts.Body != null && parts.Body.Data != null)
                            {
                                str += parts.Body.Data;
                            }
                        }
                        else
                        {
                            return getNestedParts(parts.Parts, str);
                        }
                    }
    
                    return str;
                }
    
            }
    
            /// <summary>
            /// Turn a URL encoded base64 encoded string into readable UTF-8 string.
            /// </summary>
            /// <param name="sInput">base64 URL ENCODED string.</param>
            /// <returns>UTF-8 formatted string</returns>
            private string DecodeURLEncodedBase64EncodedString(string sInput)
            {
                string[] asInput = sInput.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
                string sOutput = string.Empty;
    
                foreach (string sInputPiece in asInput)
                {
                    string sBase46codedBody = sInputPiece.Replace("-", "+").Replace("_", "/");  //get rid of URL encoding, and pull any current padding off.
                    string sPaddedBase46codedBody = sBase46codedBody.PadRight(sBase46codedBody.Length + (4 - sBase46codedBody.Length % 4) % 4, '=');  //re-pad the string so it is correct length.
    
                    byte[] data = Convert.FromBase64String(sPaddedBase46codedBody);
                    sOutput += Encoding.UTF8.GetString(data);
                }
    
                System.Diagnostics.Debug.Print("{0}\r\n\r\n", sOutput);
    
                return sOutput;
            }
        }
    }
