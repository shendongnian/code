    public class Employee
    {
        private int salary;
    
        [XmlIgnore]
        public int Salary1 { get; set; }
    
        [XmlIgnore]
        public int Salary2 { get; set; }
    
        [XmlAttribute(AttributeName = "Salary")]
        public int SalaryToSerialize
        {
            get
            {
                salary = Math.Max(this.Salary1, this.Salary2);
                return salary;
            }
            set
            {
                salary = value;
            }    
        }
    }
