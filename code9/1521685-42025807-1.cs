    public partial class Form2 : Form {
      public TabControl tabControl;
      public Form2(TabControl parentTC) {
        InitializeComponent();
        tabControl = parentTC;
      }
      private void btnSubmit_Click(object sender, EventArgs e) {
        string newText = txtDescription.Text.ToString(); //New Text 
        string tabName = txtTabName.Text.ToString();   //Name of the Tab to reference
        //int txtChanged = Int32.Parse(txtChanged.Text.ToString());  <-- changed this variable name
        int changeValue = Int32.Parse(txtChanged.Text.ToString());  //0 = No Change, 1 = Change
        int jobID = Int32.Parse(hidJobID.Text.ToString());  //Job ID 
        int rowIndex = Int32.Parse(hidRowIndex.Text.ToString());  //The row we must reference in our DataGridView
        //Call the public method from Form1 to define the Tab Control
        //TabControl tabControl = Form1.xTabControl;  <-- This parent tab control is already defined above
        //Define the Tab Page
        TabPage tbpage = new TabPage();
        tbpage = tabControl.TabPages[tabName];
        //If there is a Tab Page with that name then revise the cell
        if (tbpage != null) {
          //Define a DataGridView object
          DataGridView dgv = new DataGridView();
          //Find the DataGridView inside the TabPage (there is only 1 per Tab Page)
          foreach (Control ctrl in tbpage.Controls) {
            dgv = (ctrl is DataGridView) ? (DataGridView)ctrl : dgv;
          }
          dgv.ReadOnly = false;
          DataGridViewCell cellDescription = dgv.Rows[rowIndex].Cells[6];
          DataGridViewCell cellCatName = dgv.Rows[rowIndex].Cells[7];
          DataGridViewCell cellCat = dgv.Rows[rowIndex].Cells[8];
          if (changeValue > 0) {
            MessageBox.Show(cellDescription.Value.ToString());  //<-- This returns the correct string on the DataGridView
            dgv.CurrentCell = cellDescription;
            cellDescription.ReadOnly = false;
            cellDescription.Value = newText;  //<-- This should update the Cell, but it isnt!
          }
          else {
          }
        }
      }
    }
