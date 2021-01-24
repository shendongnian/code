    public partial class UsersDepartment{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }//No matching property in Department
        public virtual User User { get; set; }//No matching property in Department
