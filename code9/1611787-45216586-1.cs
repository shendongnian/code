    public partial class Employee
    {
       public int ID { get; set; }
       public string EmployeeLAN { get; set; }
       public int LastActionUserID { get; set; }
       public virtual IEnumerable<Skill> Skills{ get; set; }
    }
