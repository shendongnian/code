    List<Person> persons = new List<Person>();
    private void AddButton_Click(object sender, EventArgs e)
    {
        persons.Add(new Person
        {
            Name = nameBox.Text,
            Weight = double.Parse(weightBox.Text),
            Height = double.Parse(heightBox.Text)
        });
    }
