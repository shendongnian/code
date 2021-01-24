      private void BindDropdownList(IEnumerable<User> users)
      {
         // add Enumerable users "New User" Item
         users.ToList().Add(new User(){ .. , .. , .. });
         
          
        selectuser_dropdown.DataSource = users;
        selectuser_dropdown.DisplayMember = "FullName";
        selectuser_dropdown.ValueMember = "Id";
        
        // or 
        // selectuser_dropdown.Items.Insert(0, "+ New User"); 
      }
