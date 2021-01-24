    using System.Web.Script.Serialization;
    public class Employees
    {
        public string PersonRef;
        public string Firstname;
        public string Surname;
        public string PrefName;
        public string Telephone;
        public string PostRef;
        public string PostTitle;
        public string Department;
        public string Section;
        public string Location;
        public string Email;
        [ScriptIgnore]
        public string Manager;
        [ScriptIgnore]
        public string ManagersEmail;
    }
