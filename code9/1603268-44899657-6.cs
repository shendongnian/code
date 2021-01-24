    DataGridView parentDGV;
    int editRowIndex;
    // Constructor to Add a new row
    public Form2(DataGridView dgv) {
      parentDGV = dgv;
      InitializeComponent();
    }
    // Constructor to Edit a row
    public Form2(DataGridView dgv, int rowIndex) {
      parentDGV = dgv;
      editRowIndex = rowIndex;
      InitializeComponent();
      SetEditForm();
    }
    // update form for edit mode
    private void SetEditForm() {
      btnAddToGrid.Text = "Update";
      this.btnAddToGrid.Click -= this.btnAddToGrid_Click;
      this.btnAddToGrid.Click += new System.EventHandler(this.btnAddToGrid_EditClick);
      if (parentDGV.Rows[editRowIndex].Cells["AName"].Value != null)
        txtName.Text = parentDGV.Rows[editRowIndex].Cells["AName"].Value.ToString();
      else
        txtName.Text = "";
      if (parentDGV.Rows[editRowIndex].Cells["Format"].Value != null)
        txtFormat.Text = parentDGV.Rows[editRowIndex].Cells["Format"].Value.ToString();
      else
        txtFormat.Text = "";
      // set combo box value
    }
    // Button click event to update form1’s grid
    private void btnAddToGrid_EditClick(object sender, EventArgs e) {
      parentDGV.Rows[editRowIndex].Cells["AName"].Value = txtName.Text;
      parentDGV.Rows[editRowIndex].Cells["Format"].Value = txtFormat.Text;
      this.Close();
    }
    
    // Button click event to add a row to form1’s grid
    private void btnAddToGrid_Click(object sender, EventArgs e) {
      parentDGV.Rows.Add(txtName.Text, txtFormat.Text);
    }
