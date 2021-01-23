    void LoadData() {
                try {
                    XDocument xmlDocument = XDocument.Load(GetPathToFile());
    
                    rootNode.Nodes.Clear();
                    documents.Clear();
    
                    foreach(XElement el in xmlDocument.Root.Elements()) {
                        switch(el.Name.LocalName) {
                            case "Page":
                                string nodeName = el.Attribute("nodeName").Value;
                                string pageGuid = el.Attribute("pageGuid").Value;
                                string rtf = el.Attribute("Rtf").Value;
    
                                rootNode.Nodes.Add(new DataNode(nodeName, pageGuid));
                                documents.Add(pageGuid, rtf);
                                break;
                            case "Text":
                                textEdit1.Text = el.Attribute("text").Value;
                                break;
                        }
                    }
                } catch(Exception ex) {
                    MessageBox.Show("No data loaded. Check XML file");
                }
                treeList1.RefreshDataSource();
            }
