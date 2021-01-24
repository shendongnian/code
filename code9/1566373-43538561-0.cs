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
           // Select all Employee elements
            var employees = _doc.XPathSelectElements("Employees/Employee");
            // Loop the elements and check on condition
            foreach (var emp in employees.Elements())
            {
                if (emp.Name == "Telephone")
                {
                    if (emp.Value == phoneNumber)
                    {
                        MessageBox.Show(emp.Parent.Name.ToString());
                    }
                }
            }
