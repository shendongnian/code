    @using DotNetNuke.Common;
    @using DotNetNuke.Entities.Users;
    
    @{
    	var userInfo = UserController.Instance.GetCurrentUserInfo();
    }
    
    @if (userInfo.IsInRole("Administrators")) {
    	<div style="background-color:red;">IS ADMIN</div>
    }
    else if (userInfo.IsInRole("Dealers")) {
    	<div style="background-color:blue;">IS DEALER</div>
    }
