    public class FirstForm
    {
        private Person GetSelectedPerson();
        {
            Person selected = null;
            using(var secondForm = new SecondForm())
            {
                secondForm.ShowDialog();
                selected = secondForm.SelectedPerson;
            }
            return selected;
        }
        //And use above method in button click eventhandler
        private void Button_Click(object sender, EventArgs e)
        {
            Person selected = this.GetSelectedPerson();
            if(selected != null)
            {
                //Show selected data in the textboxes
                this.TextBoxNo.Text = selected.No;
                this.TextBoxName.Text = selected.Name;
                this.TextBoxAddress.Text = selected.Address;
            }
        }
    }
