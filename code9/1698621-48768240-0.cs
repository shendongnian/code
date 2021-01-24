     private void dgvSupplierPlants_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var data = ((SupplierPlant)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem); //Get the Data for the edited Row.
            if (AppData.Db.Entry(data).State == EntityState.Detached)
            {
                AppData.SupplierPlants.Add(data);
            }
        }
