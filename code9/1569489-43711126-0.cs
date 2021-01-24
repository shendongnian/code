    public class EmployeesViewModel
        {
            public int SelectedOfficeID { get; set; }
            public int SelectedEquipmentID { get; set; }
    
            public int UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
    
            public List<Office> OfficeList { get; set; }
            public List<Equipment>  EquipmentList { get; set; }
        }
    
        public class Equipment
        {
            public int EquipmentID { get; set; }
            public string EquipmentName { get; set; }
        }
    
        public class Office
        {
            public int OfficeID { get; set; }
            public string OfficeName { get; set; }
        }
