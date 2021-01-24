    private void EmpDataGrid_MouseClick(object sender, MouseEventArgs e)
        {
          
            if (EmpDataGrid.SelectedRows[0].Cells[3].Value.Equals("Female"))
                FemaleRadioBtn.Checked = true;
            else
                FemaleRadioBtn.Checked = false;
            if (EmpDataGrid.SelectedRows[0].Cells[3].Value.Equals("Male"))
                MaleRadioBtn.Checked = true;
            else
                MaleRadioBtn.Checked = false;
         }
