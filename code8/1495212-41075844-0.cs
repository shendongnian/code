    hali_sahaEntities con = new hali_sahaEntities();
         Users user = new Users();
            
            user.Name = textBox1.Text;
            user.Surname = textBox7.Text;
            user.IdentityNumber = Convert.ToInt32( textBox2.Text);
            user.Adress = textBox5.Text;
            user.Comment = textBox6.Text;
           
            Emails email = new Emails();      
            email.TCKN = Convert.ToInt32( textBox2.Text);
            email.Email = textBox4.Text;
            user.Email.Add(email);//Email is virtual proparty
           
            Phones phone = new Phones();
            phone.TCKN = Convert.ToInt32(textBox2.Text);
            phone.Phone = textBox3.Text; 
            user.Phone.Add(phone);//Phone is virtual proparty
           
            con.Users.Add(user);
            con.SaveChanges();
