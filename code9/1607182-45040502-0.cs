        private List<string> getSceneryTypeObjectiveTextList(string xml, int sceneryTypeId, string xpath = "/MissionObjectives/Theme/SceneryType")
        {
            List<string> result = null;
            XmlDocument doc = null;
            XmlNodeList sceneryTypeNodes = null;
            
            try
            {
                doc = new XmlDocument();
                doc.LoadXml(xml);
                sceneryTypeNodes = doc.SelectNodes(xpath);
                if (sceneryTypeNodes != null)
                {
                    if (sceneryTypeNodes.Count > 0)
                    {
                        foreach (XmlNode sceneryTypeNode in sceneryTypeNodes)
                        {
                            if (sceneryTypeNode.HasChildNodes)
                            {
                                var textNode = from XmlNode n in sceneryTypeNode.ChildNodes
                                               where (n.NodeType == XmlNodeType.Text && n.Value.Replace("\r", "").Replace("\n", "").Replace(" ", "") == sceneryTypeId.ToString())
                                               select n;
                                if (textNode.Count() > 0)
                                {
                                    XmlNodeList objectiveNodes = sceneryTypeNode.SelectNodes("Objective");
                                    if (objectiveNodes != null)
                                    {
                                        result = new List<string>(objectiveNodes.Count);
                                        foreach (XmlNode objectiveNode in objectiveNodes)
                                        {
                                            result.Add(objectiveNode.InnerText.Replace("\r", "").Replace("\n", "").Trim());
                                        }
                                        // Could break out of the iteration, here, if we know that SceneryType is always unique (i.e. - no duplicates in Element text node)
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            finally
            {
            }
            return result;
        }
        private sampleCall(string filePath, int sceneryTypeId)
        {
            List<string> compatibleObjectivesList = null;
            try
            {
                compatibleObjectivesList = getSceneryTypeObjectiveTextList(File.ReadAllText(filePath), sceneryTypeId);
            }
            catch (Exception ex)
            {
		// Handle error
            }
            finally
            {
            }
        }
