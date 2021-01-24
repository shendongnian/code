    public class GroupRightsVM // represents a table cell
    {
        public short GroupID { get; set; }
        public bool IsSelected { get; set; }
    }
    public class RightsVM // represents a table row
    {
        public RightsVM()
        {
            Groups = new List<GroupRightsVM>()
        }
        public EnFunction Right { get; set; }
        public List<GroupRightsVM> Groups { get; set; } // represents the cells in a row
    }
    public class PermissionsVM // Represents the table
    {
        public PermissionsVM()
        {
            Permissions = new List<RightsVM>()
        }
        public IEnumerable<string> Headings { get; set; } // represents the table headings
        public List<RightsVM> Permissions { get; set; } // represents all rows
    }
    
