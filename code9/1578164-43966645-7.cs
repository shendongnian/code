    using (FormModel frm = new FormModel(modelBindingSource.Current as Model))
    {
        if (frm.ShowDialog() == DialogResult.OK)
        {
            modelBindingSource.DataSource = db2.Models.ToList(); // not sure if you need this
            db2.SaveChanges(); // <-- call save here since the dialog has been closed.
        }
    }
