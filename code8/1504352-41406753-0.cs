         public class Item
                {
                    public string itemCode { get; set; }
                    public string positionComponent { get; set; }
                    public decimal dollarAmount { get; set; }
                    public decimal gdbAmount { get; set; }
            }
    
        try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("Write down full path");
                        XmlNodeList dataNodes = xmlDoc.SelectNodes("/return-data");
    
                        foreach (XmlNode node in dataNodes)
                        {
                            Item objItem = new Item();
                         
                       objItem.itemCode=node.SelectSingleNode("item-code").InnerText;
    objItem.positionComponent=node.SelectSingleNode("position-component").InnerText;
    objbook.dollarAmount=Convert.ToDecimal(node.SelectSingleNode("us-dollar/amount").InnerText);
    
    objbook.gdbAmount=Convert.ToDecimal(node.SelectSingleNode("gdb/amount").InnerText);
    
                        }
    
                    }
    catch(Exception ex)
    {
    throw ex;
    }
