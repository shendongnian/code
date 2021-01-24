    public enum AccessRoles
    {
        SysAdmin = 1,
        Admin = 2,
        OrgAdmin = 3
    }
        
    public class Attributes
    {
        public static Dictionary<int, Guid> Attribute = new Dictionary<int, Guid>()
        {
            {1, Guid.Parse("6D18698C-04EC-4E50-84DB-BE513D5875AC")},
            {2, Guid.Parse("32E86718-7034-4640-9076-A60B9B6CA51A")},
            {3, Guid.Parse("2CA39E37-8AEA-463F-AE14-E9D92AC5FB5E")}
        };
    }
    Console.WriteLine(Attributes.Attribute[(int)AccessRoles.SysAdmin]);
    Console.WriteLine(Attributes.Attribute[(int)AccessRoles.Admin]);
    Console.WriteLine(Attributes.Attribute[(int)AccessRoles.OrgAdmin]);
