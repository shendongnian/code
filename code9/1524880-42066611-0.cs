    DataGridViewColumn col = new DataGridViewColumn();
    col.DataPropertyName = nameof(Invoice.Amount); //This binds the value to your column
    col.HeaderText = "Amount";
    col.Name = "Amount";
    dgViewStudents.Columns.Add(col);
