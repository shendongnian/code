    public class CustomComparerForRoleCode : IComparer<PersonRole[]>
    {
        public string PersonInRole { get; set; }
        
        public CustomComparerForRoleCode(string personInRole) {
            this.PersonInRole = personInRole;
        }
        public int Compare(PersonRole[] x, PersonRole[] y) {
            var roleCode = x.First(r => r.Person == PersonInRole).AccountRoleCode;
            var otherRoleCode = y.First(r => r.Person == PersonInRole).AccountRoleCode;
            if (roleCode == otherRoleCode)
                return 0;
            switch (roleCode) {
                case "O":
                    return 1;
                case "BE":
                    return -1;
                case "CO":
                    if (otherRoleCode == "O")
                        return -1;
                    return 1;
            }
        }
    }
