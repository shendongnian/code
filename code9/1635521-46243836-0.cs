    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApp1
    {
	    public partial class Form1 : Form
	    {
		    public Form1()
		    {
			    InitializeComponent();
		    }
		    private List<GenericIdNameClass> users = new List<GenericIdNameClass>() 
            {
			    new GenericIdNameClass { Id = 1, Name = "John" },
			    new GenericIdNameClass { Id = 2, Name = "Bob" },
		    };
		    private List<GenericIdNameClass> roles = new List<GenericIdNameClass>() {
			    new GenericIdNameClass { Id = 10, Name = "User" },
			    new GenericIdNameClass { Id = 11, Name = "Admin" },
		    };
		    private List<GenericIdNameClass> actions = new List<GenericIdNameClass>() {
			    new GenericIdNameClass { Id = 100, Name = "View" },
			    new GenericIdNameClass { Id = 101, Name = "Create/Edit" },
			    new GenericIdNameClass { Id = 102, Name = "Delete" },
		    };
		    List<GenericEntityRelationClass> roleActionMappings = new List<GenericEntityRelationClass>() {
			    new GenericEntityRelationClass{ Id1 = 10, Id2 = 100 },
			    new GenericEntityRelationClass{ Id1 = 11, Id2 = 100 },
			    new GenericEntityRelationClass{ Id1 = 11, Id2 = 101 },
			    new GenericEntityRelationClass{ Id1 = 11, Id2 = 102 },
		    };
		    // John only has User role, Bob has User and Admin
		    List<GenericEntityRelationClass> userRoleMappings = new List<GenericEntityRelationClass>() {
			    new GenericEntityRelationClass{ Id1 = 1, Id2 = 10 },
			    new GenericEntityRelationClass{ Id1 = 2, Id2 = 10 },
			    new GenericEntityRelationClass{ Id1 = 2, Id2 = 11 },
		    };
		    private bool HasPermission(string userName, string actionName)
		    {
			    var user = users.SingleOrDefault(x => x.Name == userName);
			    if (user == null)
				    return false;
			    var action = actions.SingleOrDefault(x => x.Name == actionName);
			    if (action == null)
				    return false;
			    var userRoles = userRoleMappings.Where(x => x.Id1 == user.Id).Select(x => x.Id2).ToList();
			    return roleActionMappings.Any(x => userRoles.Contains(x.Id1) && x.Id2 == action.Id);
		    }
		    private void Form1_Load(object sender, EventArgs e)
		    {
			    var canJohnView = HasPermission("John", "View");
			    var canJohnDelete = HasPermission("John", "Delete");
			    var canBobView = HasPermission("Bob", "View");
			    var canBobDelete = HasPermission("Bob", "Delete");
		    }
		    public class GenericIdNameClass
		    {
			    public int Id { get; set; }
			    public string Name { get; set; }
		    }
		    public class GenericEntityRelationClass
		    {
			    public int Id1 { get; set; }
			    public int Id2 { get; set; }
		    }
	    }
    }
