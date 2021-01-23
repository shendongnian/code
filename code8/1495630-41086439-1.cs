    public class EmployeeNameDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
    
    public EmployeeNameDto GetEmployeeName(int id)
    {
        Employee emplpoyee = employeeRepository.Find(id):
        return new EmployeeNameDto() {
          EmployeeId = emplpoyee.EmployeeId,
          FirstName = emplpoyee.FirstName,
          MiddleName = emplpoyee.MiddleName,
          LastName = emplpoyee.LastName
        };
    }
