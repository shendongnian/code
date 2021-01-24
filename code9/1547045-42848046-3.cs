    public class EmployeeDTO
    {
    
        public string LName { get; set; }
        public string FName { get; set; }
        public string Title { get; set; }
     
    
        //Navigation Property
        public List<EmployeeApplicationsDTO> EmployeeApplicationsDTO { get; set; }
    }
    
    public class EmployeeApplicationsDTO
    {
        public Application Application { get; set; }
    
    }
