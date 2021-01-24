    class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var combinedProductGroups = (from organizationalUnit
                    in user.OrganizationalUnit
                    select organizationalUnit.ProductGroup)
                .Concat(from subOrganizationalUnit
                    in user.SubOrganizationalUnit
                    select subOrganizationalUnit.ProductGroup);
            var productGroupIdList = from productGroup in combinedProductGroups
                    select productGroup.ProductGroupId;
            
        }
    }
    public class User
    {
        public List<OrgUnit> OrganizationalUnit;
        public List<SubOrgUnit> SubOrganizationalUnit;
    }
    public class OrgUnit
    {
        public ProdGroup ProductGroup;
    }
    public class SubOrgUnit
    {
        public ProdGroup ProductGroup;
    }
    public class ProdGroup
    {
        public string ProductGroupId;
    }
 
