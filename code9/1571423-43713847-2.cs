    private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstNames.SelectedItem != null)
        {
            PersonEntry person = lstNames.SelectedItem as PersonEntry;
            if(person != null)
            {
                //Create second form for these details
                Informationform form2 = new Informationform(person.Name, person.Email, person.Phone);
                form2.ShowDialog();
            }
        }
        else
        {
            MessageBox.Show("Please pick a name!");
        }
    }
