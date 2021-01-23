    Person[] persons = new Person[10];
    private void AddButton_Click(object sender, EventArgs e)
    {
         persons[index] = new Person
            {
                Name = nameBox.Text,
                Weight = double.Parse(weightBox.Text),
                Height = double.Parse(heightBox.Text)
            };
            index++;
    }
