    using System.Linq;
    //...
    var roles = roleManager.Roles.ToList();
    List<string> userRoles = manager.GetRoles(user.Id);
    var ununsedRoles = roles.Execpt(userRoles);
