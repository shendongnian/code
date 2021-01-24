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
            // load file XDocument
            XDocument _doc = XDocument.Load("C:\\t\\My File2.txt");
            /*
             1. Select Employees
                2. Select the Employee Element
                   3.Search int this Employee for elements with name "Telephone"
                      4.Extract the value and compare it to your given number
                5. Continue to the next Employee to comaire
             6.Select the first on of all the elements that for filled the search term
             */     
             var employee = _doc.Element("Employees")
                .Elements("Employee")
                .Where(x => x.Element("Telephone")?
                .Value == "00000000")
                .FirstOrDefault();  
             // Get values from elements of Employee
             string name = employee.Element("Name").Value;
             string age = employee.Element("Age").Value;
            MessageBox.Show($"Name: {name}, Age {age}");
