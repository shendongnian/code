     public void ButtonAdd_Click(object sender, EventArgs e)
        {
            // Use the Constructor with Parameters 
            Person p = new Person(TextBoxName.Text, TextBoxAge.Text, TextBoxPassword.Text);
    // Use the ToString() of your Person
                ListBoxAll.Items.Add(p.ToString());
            
            if (p.Age > 18)
            {
                ListBoxAdults.Items.Add(p.ToString());    
            }                 
            else
            {    
                ListBoxKids.Items.Add(p.ToString());    
            }                        
        }    
