    Read Write textFile
    
    --------------------
    
     
    
           public void Loaddetails()
                    {
                        List<string> inputList = new List<string>();
                        string path = @"H:\Desktop\Prj Local\TradeList.txt";
             
                        StreamReader strReader = new StreamReader(path);
                        string line = "";
             
                        while ((line = strReader.ReadLine())!= null)
                        {
                            if(line.Length>0)
                            {
                                inputList.Add(line);
                            }
                        }
                        List<TradeList> ValidList = new List<TradeList>();
                        List<TradeList> InvalidList = new List<TradeList>();
                        foreach (string lsttovalid in inputList)
                        {
                            DateTime outDate = new DateTime();
                            DateTime outMatDate = new DateTime();
                            string[] splist = lsttovalid.Split(',');
             
                            if (splist[0]!=null && splist[0].StartsWith("TR")&&System.Text.RegularExpressions.Regex.IsMatch(splist[1],@"^ISIN\d{3}$") &&
                                DateTime.TryParseExact(splist[2],"MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out outDate)&&
                                DateTime.TryParseExact(splist[3],"MM/dd/yyyy",null,System.Globalization.DateTimeStyles.None, out outMatDate)&&
                                outMatDate > outDate.AddYears(5)&& splist[4]!=null&& System.Text.RegularExpressions.Regex.IsMatch(splist[5],@"^[a-zA-Z]{3}$"))
                            {
                                TradeList vtd = new TradeList();
             
                                vtd.TradeId = splist[0];
                                vtd.TradeType = splist[1];
                                vtd.TradeDate = Convert.ToDateTime(splist[2]);
                                vtd.MaturityDate = Convert.ToDateTime(splist[3]);
                                vtd.Tradevalue = splist[4];
                                vtd.Currency = splist[5];
                                vtd.Money = Convert.ToInt32(splist[6]);
             
                                ValidList.Add(vtd);
                            }
                            else
                            {
                                TradeList etd = new TradeList();
             
                                etd.TradeId = splist[0];
                                etd.TradeType = splist[1];
                                etd.TradeDate = Convert.ToDateTime(splist[2]);
                                etd.MaturityDate = Convert.ToDateTime(splist[3]);
                                etd.Tradevalue = splist[4];
                                etd.Currency = splist[5];
                                etd.Money = Convert.ToInt32(splist[6]);
             
                                InvalidList.Add(etd);
                            }
                        }
             
                        List<string> Invalid = new List<string>();
             
                        foreach (TradeList trd in InvalidList)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(trd.TradeId + ',');
                            sb.Append(trd.TradeType + ',');
                            sb.Append(Convert.ToDateTime(trd.TradeDate).ToShortDateString().ToString() + ',');
                            sb.Append(Convert.ToDateTime(trd.MaturityDate).ToShortDateString().ToString() + ',');
                            sb.Append(trd.Tradevalue + ',');
                            sb.Append(trd.Currency + ',');
                            sb.Append(trd.Money);
             
                            string str = sb.ToString();
                            Invalid.Add(str);
                        }
                        
                        string Epath = @"H:\Desktop\Prj Local\ErrorList.txt";
             
                        if (File.Exists(Epath))
                        {
                            File.Delete(Epath);               
                        }
             
                        using (StreamWriter swrite = new StreamWriter(Epath))
                        {
                            foreach (var lines in Invalid)
                            {
                                swrite.WriteLine(lines);
                            }
                        }      
                    }
             
             
             
                    static void Main(string[] args)
                    {
                        Program P = new Program();
                         P.Loaddetails();
                        //Console.WriteLine(Result("CVB000","10/07/2017"));
                        Console.ReadLine();
                    }
    
    XML
    ------
    
    
    namespace ConsoleApplication12
    {    
       [Serializable]
       public  class Trade
        {
            public int tradeid;
            public string tradename;
            public string tradeemail;
            public DateTime tradedate;
     
        }
    }
     
     
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Trade> lstTd = new List<Trade>();
                XElement xe = XElement.Load(@"H:\Workspace\TEST\test.xml");
                IEnumerable<XElement> iExe=  xe.Elements();
     
                foreach(var ele in iExe)
                {
                    Trade trd = new Trade();
                    trd.tradeid = Convert.ToInt32(ele.Element("Id").Value);
                    trd.tradename = ele.Element("Name").Value;
                    trd.tradeemail = ele.Element("Email").Value;
                    trd.tradedate = Convert.ToDateTime(ele.Element("Date").Value);
     
                    lstTd.Add(trd);
                }
     
                XmlDocument xDoc = new XmlDocument();
                XmlNode parentNode = xDoc.CreateElement("TradesMain");
                xDoc.AppendChild(parentNode);
                foreach (var trd in lstTd)
                {
                    XmlNode secondParentNode = xDoc.CreateElement("Trades");
     
                    XmlNode firstChildNode = xDoc.CreateElement("TradeID");
                    firstChildNode.InnerText = trd.tradeid.ToString();
                    secondParentNode.AppendChild(firstChildNode);
     
                    XmlNode scChildNode = xDoc.CreateElement("TradeName");
                    scChildNode.InnerText = trd.tradename;
                    secondParentNode.AppendChild(scChildNode);
     
                    XmlNode trChildNode = xDoc.CreateElement("TradeEmail");
                    trChildNode.InnerText = trd.tradeemail;
                    secondParentNode.AppendChild(trChildNode);
     
                    XmlNode frChildNode = xDoc.CreateElement("TradeDate");
                    frChildNode.InnerText = trd.tradedate.ToString();
                    secondParentNode.AppendChild(frChildNode);
     
                    parentNode.AppendChild(secondParentNode);
                  
                }
                xDoc.Save(@"H:\Workspace\TEST\testout.xml");
     
                Console.WriteLine("ok");
     
                XmlSerializer ser = new XmlSerializer(typeof(List<Trade>));
     
                using (StreamWriter sw = new StreamWriter(@"H:\Workspace\TEST\testserout.xml"))
                {
                    ser.Serialize(sw, lstTd);
                }
               
            }
        }
    }
     
     
     
    <?xml version="1.0" encoding="utf-8" ?> 
    - <Employees> 
    - <Employee> 
    <Id>1</Id> 
    <Name>Sam</Name> 
    <Email>Sam@gmail.com</Email> 
    <Date>12/24/2013</Date> 
    </Employee> 
    - <Employee> 
    <Id>2</Id> 
    <Name>Lucy</Name> 
    <Email>Lucy@gmail.com</Email> 
    <Date>12/26/2013</Date> 
    </Employee> 
    - <Employee> 
    <Id>3</Id> 
    <Name>Kate</Name> 
    <Email>Kate@gmail.com</Email> 
    <Date>12/27/2013</Date> 
    </Employee> 
    - <Employee> 
    <Id>1</Id> 
    <Name>Sam</Name> 
    <Email>Sam@gmail.com</Email> 
    <Date>12/24/2014</Date> 
    </Employee> 
    </Employees>
