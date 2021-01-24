          ContextMenu menu = new ContextMenu();
          MenuItem deleteMenu = new MenuItem( "Delete" );
          deleteMenu.Click += DeleteMenu_Click;
          menu.MenuItems.Add( deleteMenu );
          
    
       }
    
       private void DeleteMenu_Click( object sender, EventArgs e )
       {
          // put your code in here
       }
