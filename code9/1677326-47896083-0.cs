    public class CustomComparerForRoleCode : IComparer<PersonRole[]>
    {
        public string PersonInRole { get; set; }
        
        public CustomComparerForRoleCode(string personInRole) {
            this.PersonInRole = personInRole;
        }
        public int Compare(PersonRole[] x, PersonRole[] y) {
            var roleCode = x.First(r => r.Person == PersonInRole).AccountRoleCode;
            var otherRoleCode = y.First(r => r.Person == PersonInRole).AccountRoleCode;
            // write compare logic to order the codes
        }
    }
