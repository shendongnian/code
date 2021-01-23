                var extraParamsList = new List<System.Xml.Linq.XElement> ();
                extraParamsList.Add (new System.Xml.Linq.XElement ((System.Xml.Linq.XName)"save_to_history", 1));
                extraParamsList.Add (new System.Xml.Linq.XElement ((System.Xml.Linq.XName)"send_to_chat", 1));
                extraParamsList.Add (new System.Xml.Linq.XElement ((System.Xml.Linq.XName)"message_text", messageTextEncoded));
                var extraParams = new System.Xml.Linq.XElement ((System.Xml.Linq.XName)EXTRA_PARAMS, extraParamsList.ToArray ());
                quickbloxClient.ChatXmppClient.SendMessage (recieverId, messageText, extraParams, dialogId, null, Xmpp.Im.MessageType.Chat);
