    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebFormsHelloWorld
    {
    	public partial class _Default : Page
    	{
    		protected void Page_Load(object sender, EventArgs e)
    		{
                if(!IsPostBack)
                {
                    var users = new List<User>
                    {
                        new User { Name = "Luke Skywalker", Email="luke@skywalker.com", Group = "Admin"},
                        new User { Name = "Han Solo", Email="han@solo.com", Group = "Advisor"},
                        new User { Name = "Leia Organa", Email="lea@alderan.com", Group = "User"},
                    };
    
                    UsersRepeater.DataSource = users;
                    UsersRepeater.DataBind();
                }
    		}
    
            protected void Unnamed_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList changedDropDownList = sender as DropDownList;
                var parentRow = changedDropDownList.Parent;
                var hiddenField = parentRow.FindControl("UsersNameHiddenField") as HiddenField;
                var userName = hiddenField.Value;
                Debug.WriteLine($"User {userName}, new group {changedDropDownList.SelectedValue}");
            }
        }
    
        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Group { get; set; }
        }
    }
