    private void regButton_Click(object sender, EventArgs e)
    {
        var person = new Person
        {
            Name = userTextBox.Text,
            Pass = passTextBox.Text
        };
        Holder.Instance.People.Add(person);
        this.Close();
        MessageBox.Show(person.Ts());
    }
