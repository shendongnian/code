    protected void Page_Load(object sender, EventArgs e)
        {
            // Perform The UI Logic 
            // Assuming That You Are Tracking The User For Each Reqeust In Session["UserID"]
            ShowHideMenuOrSubMenu_Role_Your_RoleName(Session["UserID"].ToString());
        }
        public static void ShowHideMenuOrSubMenu_Role_Your_CRUD_RoleName(string UserID)
        {
            if (CheckUserRole("Your_CRUD_Role", UserID))
            {
                //1. Set Your Front End WebForm Control To Disable
                //2. Set Your Front End WebForm Control CSS 
                // Whichever you prefer . 
            }
        }
        public static bool CheckUserRole(string Role_CRUD , string UserID)
        {
            // Go Into DB/Repository/EF Where Your Role/User Setting Is Set .
            // Perform Checking
            // Assuming The Result Is A Bool Checking Result That You Checked
            return Result;
        }
