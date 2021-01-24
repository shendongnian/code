    Bitmap img = new Bitmap(@"C:\2946.jpg");
    // Add the DataGridView with an image column
    DataGridView dgv = new DataGridView();
    this.Controls.Add(dgv);
    DataGridViewImageColumn imageCol = new DataGridViewImageColumn(); 
    dgv.Columns.Add(imageCol);
    
    // Add a row and set its value to the image
    dgv.Rows.Add();   
    dgv.Rows[0].Cells[0].Value = img;
