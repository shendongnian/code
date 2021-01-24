                    List<string> options = null;
                    string option = "";
                    foreach (XmlNode node in memberlist)
                    {
                        option = node.SelectSingleNode("option").InnerText;
                        options.add(option); //Put the value into the list.
                    }
