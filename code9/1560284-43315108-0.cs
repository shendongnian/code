    else if (mode.Equals("Update"))
            {
                String id= txtuserId.Text; // change this part
    
                string newName = txtname.Text;
                string newemail = txtemail.Text;
                string newpassword = txtpassword.Text;
                string newaddress = rtbaddress.Text;
                string newphoneNumber = txtphoneNumber.Text;
                string newroleName = cmbrole.Text;
    
                users updatedusers = (
                    from x in db.users
                    where x.id==id // leave it as it is
                    select x
                    ).First();
            }
