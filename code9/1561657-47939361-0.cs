    SAPbouiCOM.Menus oMenus = null;
    SAPbouiCOM.MenuItem oMenuItem = null;
    //**********************************************************
    oMenus = SBO_Application.Menus;
    SAPbouiCOM.MenuCreationParams oCreationPackage = null;
    //**********************************************************
    //Creating a new menu item after the menu whose UID is
    //"3328"
    //**********************************************************
    oCreationPackage = ( ( SAPbouiCOM.MenuCreationParams )( SBO_Application.CreateObject( SAPbouiCOM.BoCreatableObjectType.cot_MenuCreationParams ) ) );
    oMenuItem = SBO_Application.Menus.Item( "3328" );
    try{
    //**********************************************************
    //Adding the new menu to the main menu
    //**********************************************************
	    oMenus.AddEx( oCreationPackage );
	    oMenuItem = SBO_Application.Menus.Item( "3328" );
	//**********************************************************
    //Adding the sub menu of string type to the newly added menu
    //**********************************************************
        
        oMenus = oMenuItem.SubMenus;
        oCreationPackage.Type = SAPbouiCOM.BoMenuType.mt_STRING;
	    oCreationPackage.UniqueID = "routesheet";
	    oCreationPackage.String = "RouteSheet";
	    oMenus.AddEx( oCreationPackage );
    }
