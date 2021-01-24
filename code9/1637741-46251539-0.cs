            public class Dialog
            {
                public int id;
                public List<CallVariable> callVariables = new List<CallVariable>();
                public struct CallVariable
                {
                    public string name;
                    public string value;
                }
            }
            public List<Dialog> GetDialogsFromXml(string xml)
            {
                try
                {
                    XDocument doc = XDocument.Parse(xml);
                    List<Dialog> dialogs = new List<Dialog>();
                    foreach (XElement item in doc.Root.Descendants("{http://jabber.org/protocol/pubsub}Dialog"))
                    {
                        
                        int dialogid = int.Parse(item.Element("{http://jabber.org/protocol/pubsub}id").Value);
                        List<Dialog.CallVariable> callvariables = new List<Dialog.CallVariable>();
                        foreach (XElement callVariableNode in item.Descendants("{http://jabber.org/protocol/pubsub}callvariables").FirstOrDefault().Descendants("{http://jabber.org/protocol/pubsub}CallVariable"))
                        {
                            callvariables.Add(new Dialog.CallVariable() { name=callVariableNode.Element("{http://jabber.org/protocol/pubsub}name").Value, value = callVariableNode.Element("{http://jabber.org/protocol/pubsub}value").Value });
                        }
                        dialogs.Add(new Dialog() { id = dialogid, callVariables = callvariables });
                    }
                    return dialogs;
                }
                catch (Exception e)
                {
                    //handle if something goes wrong
                    return null;
                    
                }
            
            }
