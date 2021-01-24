    namespace DataGridAndComboBox
    {
        public partial class Form1 : Form
        {
            List<Users> users = new List<Users>();
    
            List<Months> months = new List<Months>();
    
            public Form1()
            {
                InitializeComponent();
     
                dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
                Load += Form1_Load;
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                months.Add(new Months() { ID = 1, Name = "Jan" });
                months.Add(new Months() { ID = 2, Name = "Feb" });
                months.Add(new Months() { ID = 3, Name = "Mar" });
    
    
                users.Add(new Users() { ID = 1, MonthID = 1, Name = "Trump" });
                users.Add(new Users() { ID = 2, MonthID = 2, Name = "Clinton" });
                users.Add(new Users() { ID = 3, MonthID = 3, Name = "Obama" });
                users.Add(new Users() { ID = 4, MonthID = 1, Name = "Reygan" });
                users.Add(new Users() { ID = 5, MonthID = 2, Name = "Kennedi" });
                users.Add(new Users() { ID = 6, MonthID = 3, Name = "Bush" });
    
            }
    
            //Get data from database
            private void ButtonGetData_Click(object sender, EventArgs e)
            {
                var bindingSourceMonths = new BindingSource()
                {
                    DataSource = months
                };
    
                #region Create DataGridView columns
    
                dataGridView1.Columns.Clear();
    
                var userID = new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ID user",
                    Width = 50,
                    DataPropertyName = "ID",
                    Name = "ID"
                };
                dataGridView1.Columns.Add(userID);
    
                var userName = new DataGridViewTextBoxColumn()
                {
                    HeaderText = "User Name",
                    Width = 100,
                    DataPropertyName = "Name",
                    Name = "Name"
                };
                dataGridView1.Columns.Add(userName);
    
    
                var userMonthID = new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Month",
                    Width = 100,
                    DataPropertyName = "MonthID",
                    DataSource = bindingSourceMonths,
                    ValueMember = "ID",
                    DisplayMember = "Name",
                    Name = "MonthID"
                };
                dataGridView1.Columns.Add(userMonthID);
    
                #endregion
    
                dataGridView1.DataSource = users;
            }
    
            //Update database
            private void ButtonUpdateData_Click(object sender, EventArgs e)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var userID = (int)dataGridView1.Rows[i].Cells[0].Value;
                    var userName = (string)dataGridView1.Rows[i].Cells[1].Value;
                    var userMonthID = (int)dataGridView1.Rows[i].Cells[2].Value;
                    var m = months.First(x => x.ID == userMonthID);
                }
            } 
    
            private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "MonthID")
                {
                    Users users = (Users)this.dataGridView1.CurrentRow.DataBoundItem;  
    
                    var monthName = months.First(x => x.ID == users.MonthID);
                }
            }
        }
    
    
        #region Classes
    
        public class Months
        {
            public int ID { get; set; }
    
            public string Name { get; set; }
        }
    
        public class Users
        {
            public int ID { get; set; }
    
            public string Name { get; set; }
    
            public int MonthID { get; set; }
        }
    
        #endregion
    }
