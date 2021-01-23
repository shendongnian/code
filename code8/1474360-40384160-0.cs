    Dictionary<string, Person> clients = new  Dictionary<string, Person>();
     ....
    public void AddClientButton_Click(object sender, EventArgs e)
    { 
            Person x = new Person();
            x.Name = nameTextbox.text;
            x.Address = addressTextbox.Text;
            clients.Add(x.Name, x); //Beware, if the name is not unique an exception will be thrown.
    
    }
