     namespace WindowsFormsApplication1
        {
            public partial class Form1 : Form
            {
                List<Employee> EmployeeList = new List<Employee>();
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void Form1_Load(object sender, EventArgs e)
                {
                   
        
                    Employee emp = new Employee();
        
                    emp.EmployeeAddress = "polonnaruwa";
        
                    emp.EmployeeId = 1;
                    emp.EmployeeName = "Kasun";
        
                    EmployeeList.Add(emp);
                    Employee emp1 = new Employee();
                    emp1.EmployeeAddress = "Kandy";
        
                    emp1.EmployeeId = 2;
                    emp1.EmployeeName = "Bimal";
        
                    EmployeeList.Add(emp1);
        
                    Employee emp2 = new Employee();
                    emp2.EmployeeAddress = "New Town";
        
                    emp2.EmployeeId = 3;
                    emp2.EmployeeName = "ASheain";
        
                    EmployeeList.Add(emp2);
        
                    dataGridView1.DataSource = EmployeeList;
        
                }
        
                private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
                {
                    if (this.dataGridView1.Columns[e.ColumnIndex].Name == "EmployeeName")
                    {
                        int RowIndex = e.RowIndex;
                        int columnIndex = e.ColumnIndex;
                        if (e.Value != null)
                        {
                           
                            string stringValue = (string)e.Value;
                            int val;
                            if (int.TryParse(stringValue, out val))
                            {
        
                                label1.Text = "it is integer";
                                dataGridView1.Rows[RowIndex].Cells[columnIndex].Value = "Please Enter String Value";
                               
                            }
                            else
                            {
                                label1.Text = "it is not integer";
        
                            }
        
                        }
                    }
                   
                }
        
                private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
                {
                   
                }
            }
        } 
