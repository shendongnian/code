    private void dgvContacts_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            //Make sure that the user double clicked a cell in the main body of the grid.
            if (e.RowIndex >= 0) {
                //Get the current row item.
                Contact currentContact = (Contact)dgvContacts.Rows[e.RowIndex].DataBoundItem;
                //Do whatever you want with the data in that row.
                string name = currentContact.Name;
                string phoneNum = currentContact.Phone;
                string email = currentContact.Email;
                MessageBox.Show("Name: " + name + Environment.NewLine +
                    "Phone number: " + phoneNum + Environment.NewLine +
                    "Email: " + email);
            }//if
        }//dgvContacts_CellDoubleClick
