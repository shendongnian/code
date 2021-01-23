    Class.clsMemberInfo member = new Class.clsMemberInfo();
    
    member.FirstName = txtFirstName.Text;
    member.Lastname = txtLastName.Text;
    member.Age = Convert.ToInt32(txtAge.Text);
    member.ID  = ??? //you need to give this value, otherwise your update will not work 
