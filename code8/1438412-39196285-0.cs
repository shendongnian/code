     public DialogResult Dialog(DataRowState state)
            {
    
                if (state == DataRowState.Modified)
                {
    
                    DialogResult update = MessageBox.Show("are you sure you want to update this ?", "Update Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    
                    return update;
                }
                if (state == DataRowState.Deleted)
                {
    
                    DialogResult delete = MessageBox.Show("are you sure you want to delete this ?", "Delete Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    
                    return delete;
                }
                return DialogResult.None;
    
            }
