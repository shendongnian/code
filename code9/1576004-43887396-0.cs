    class AddContact
    {
       ....
       public Contacts newContact{get;set;}
       public AddContact()
       {
           newContact = new Contacts();
       }
       private void  OnAddButtonClicked()
       {
          newContact.FirstName = "Abc";//just i am taking abc asexample you fetch data from the textbox controls
          newContact.LastName = "Abc";
          .....
          //fill all the data members
          DialogResult = true;
          this.close();
       }
    }
