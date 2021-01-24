    <Employees>
      <Employee Id="01">
        <Name> ABC </Name>
        <Telephone>123456789</Telephone>
        <Age> 25</Age>
        <MartialStatus> False </MartialStatus>
      </Employee>
      <Employee Id="02">
        <Name> XYZ </Name>
        <Telephone>00000000</Telephone>
        <Age> 25</Age>
        <MartialStatus> False </MartialStatus>
      </Employee>
    </Employees>
            
            string phoneNumber = "00000000";
            // load file XDocument
            XDocument _doc = XDocument.Load("C:\\t\\My File2.txt");
           // Select Employee element whits number is "00000000".
            var employee = doc.Descendants("Employees").Elements("Employee").Where(x => x.Element("Telephone")?.Value == "00000000").FirstOrDefault();
