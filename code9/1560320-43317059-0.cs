        class Menu
         {
           public int Id{get; set;}
           public String Title{get; set;}
           public List<MenuItems> MenuItems{get; set;}
           public int UserId {get; set;}
         }
        class MenuItem
         {
           public int MenuId{get; set;} // Link to the parent Menu Id
           public int Id{get; set;}
           public int Title{get; set;}
           public string Address{get; set;}
         }
