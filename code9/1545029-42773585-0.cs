    <TaxTbl>
      <TaxSite>
        <Location>Axx</Location>
        <Address>xxx</Address>
        <City>aaa</City>
        <State> st</State>
        <Zip>xxx</Zip>
      </TaxSite>
      <TaxSite>
        <Location>Bxxx</Location>
        <Address>xxx</Address>
        <City>xxx</City>
        <State> st</State>
        <Zip>xxx</Zip>
      </TaxSite>
    </TaxTbl>
     var xdoc = XDocument.Load("C:\\Users\\Harley\\desktop\\outfile.xml");
 
    var NewDoc = new XDocument(new XElement("TaxTbl",
                 from anEntry in xdoc.Element("TaxTbl").Elements("TaxSite")
                 where anEntry.Element("City").Value.Contains(textBox1.Text)
                 select anEntry));
 
    var MyList =
                        (from bEntry in NewDoc.Descendants("TaxSite")
                         select new
                         {
                             Location = bEntry.Element("Location").Value,
                             Address = bEntry.Element("Address").Value,
                             City = bEntry.Element("City").Value,
                             State = bEntry.Element("State").Value,
                             Zip = bEntry.Element("Zip").Value
                         }).ToList();
     cityDGV.DataSource = MyList.ToList();
   
