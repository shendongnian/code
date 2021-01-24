    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string firstName = FirstNameTextBox.Text;
        string lastName = LastNameTextBox.Text;
        // Now you can do whatever you want with the submitted values.
        // Let's display them on the page.
        ResultsLabel.Text = "Hello " + firstname + " " + lastName + "!";
        // Rather than having loose properties,
        // it's often a good idea to group your properties into a structure, 
        // such as a class that represents some concept.
        Person submittedPerson = new Person();
        submittedPerson.FirstName = firstName;
        submittedPerson.LastName = lastName;
    }
    // this class should be defined in its own file
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
