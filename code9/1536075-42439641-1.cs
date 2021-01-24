    List<Test> tests = new List<Test>()
               {
                   new Test() {EmployeeID = "1", Name = "A"},
                   new Test() {EmployeeID = "2", Name = "B"},
                   new Test() {EmployeeID = "3", Name = "C"},
                   new Test() {EmployeeID = "4", Name = "D"},
                   new Test() {EmployeeID = "5", Name = "E"},
                   new Test() {EmployeeID = "6", Name = "F"},
                   new Test() {EmployeeID = "7", Name = "G"},
                   new Test() {EmployeeID = "8", Name = "H"},
               };
    
    var x = tests.OrderBy(name => name.Name != "D")
               .ThenBy(name => name.Name != "F")
               .ThenBy(name => name.Name != "A")
               .ThenBy(name => name.Name)
               .ToList();
