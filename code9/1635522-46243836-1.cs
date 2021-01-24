    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorize : AuthorizeAttribute
    {
    	private string _action { get; set; }
    
    	public CustomAuthorize() { }
    	public CustomAuthorize(string action) { _action = action; }
    
    	protected override bool AuthorizeCore(HttpContextBase httpContext)
    	{
    		if (httpContext.User == null)
    			return false;
    
    		if (!httpContext.User.Identity.IsAuthenticated)
    			return false;
    
    		// HasPermission function implements looking up by user name and action
    		// to see if user has a role that would give them access to this action
    		return PermissionChecker.HasPermission(httpContext.User.Identity.Name, _action);
    	}
    
    	protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    	{
    		// handle unauthorized requests here
    		// return 503 error or whatever
    	}
    
    }
    
    public static class PermissionChecker
    {
    	static List<GenericIdNameClass> users = new List<GenericIdNameClass>() {
    		new GenericIdNameClass { Id = 1, Name = "John" },
    		new GenericIdNameClass { Id = 2, Name = "Bob" },
    	};
    
    	static List<GenericIdNameClass> roles = new List<GenericIdNameClass>() {
    		new GenericIdNameClass { Id = 10, Name = "User" },
    		new GenericIdNameClass { Id = 11, Name = "Admin" },
    	};
    
    	static List<GenericIdNameClass> actions = new List<GenericIdNameClass>() {
    		new GenericIdNameClass { Id = 100, Name = "View" },
    		new GenericIdNameClass { Id = 101, Name = "Create/Edit" },
    		new GenericIdNameClass { Id = 102, Name = "Delete" },
    	};
    
    	static List<GenericEntityRelationClass> roleActionMappings = new List<GenericEntityRelationClass>() {
    		new GenericEntityRelationClass{ Id1 = 10, Id2 = 100 },
    		new GenericEntityRelationClass{ Id1 = 11, Id2 = 100 },
    		new GenericEntityRelationClass{ Id1 = 11, Id2 = 101 },
    		new GenericEntityRelationClass{ Id1 = 11, Id2 = 102 },
    	};
    
    	// John only has User role, Bob has User and Admin
    	static List<GenericEntityRelationClass> userRoleMappings = new List<GenericEntityRelationClass>() {
    		new GenericEntityRelationClass{ Id1 = 1, Id2 = 10 },
    		new GenericEntityRelationClass{ Id1 = 2, Id2 = 10 },
    		new GenericEntityRelationClass{ Id1 = 2, Id2 = 11 },
    	};
    
    	public static bool HasPermission(string userName, string actionName)
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
