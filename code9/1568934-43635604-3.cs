    public class CompanyList {
        public CompanyList(fkUserType fk, string name) {
            UserId = fk;
            Name = name;
        }
        public virtual User {get; set;}
        public fkUserType UserId {get; set;}
    }
