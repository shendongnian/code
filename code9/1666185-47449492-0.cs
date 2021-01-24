     private void teacherListView_DoubleClick(object sender, EventArgs e)
            {
                {
                    if (teacherListView.SelectedItems.Count == 0)
                        return;
                      
                Id = Convert.ToInt32(teacherListView.SelectedItems[0].SubItems[0].Text.ToString());
                nameTextBox.Text =teacherListView.SelectedItems[0].SubItems[1].Text;
                designationComboBox.Text =teacherListView.SelectedItems[0].SubItems[2].Text;
                joiningDateTimePicker.Value =Convert.ToDateTime(teacherListView.SelectedItems[0].SubItems[3].Text.ToString());
                saveButton.Text = "Update";
                deleteButton.Enabled = true;
                }
         
                   
            }
