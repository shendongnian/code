    public PartialViewResult _Partially(string id)
          {
             Tool selectedTool = new Tool();
             if (id != null)
             {
                var request = (HttpWebRequest)WebRequest.Create("http://localhost/DbService/Tool/" + id);
    
                XmlDocument xml = new XmlDocument();
                Stream aResponsestream;
                string aResult = "";
                using (aResponsestream = request.GetResponse().GetResponseStream())
                using (StreamReader aReader = new StreamReader(aResponsestream, Encoding.UTF8))
    
    
                {
                   aResult = aReader.ReadToEnd();
                   aResponsestream.Close();
                }
                xml.LoadXml(aResult);
                var Description = xml.SelectSingleNode("RetrieveResponse/RetrieveResult/Tool/Description");
                if (Description != null) selectedTool.Description = Description.InnerText;
                var Adapter = xml.SelectSingleNode("RetrieveResponse/RetrieveResult/Tool/Adapter/Name");
                if (Adapter != null) selectedTool.Adapter = Adapter.InnerText;
                var TNumber = xml.SelectSingleNode("RetrieveResponse/RetrieveResult/Tool/TNo");
                if (TNumber != null) selectedTool.TNumber = TNumber.InnerText;
                var ToolId = xml.SelectSingleNode("RetrieveResponse/RetrieveResult/Tool/ToolId");
                if (ToolId != null) selectedTool.ToolId = ToolId.InnerText;
    
                return PartialView("_Partially", selectedTool);
             }
             return PartialView();
    
    
          }
