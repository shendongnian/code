    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string filePath = "sample.txt";
    
                using (var fileRdr = new StreamReader(filePath))
                {
                    var columns = fileRdr.ReadLine().Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries); 
                    CreateColumns(columns);
    
                    while (!fileRdr.EndOfStream)
                    {
                        var lineData = fileRdr.ReadLine().Split(",".ToArray(), StringSplitOptions.RemoveEmptyEntries);
                        dataGridView1.Rows.Add(lineData[0], lineData[1]);
                    }
    
                    fileRdr.Close();
                    fileRdr.Dispose();
                }
    
            }
    
            private void CreateColumns(string[] columns)
            {
                foreach (var col in columns)
                {
                    var dataColumn = new DataGridViewTextBoxColumn();
                    dataColumn.Name = col;
                    dataColumn.HeaderText = col.ToUpper();
    
                    switch(col.ToUpper())
                    {
                        case "WP":
                        case "LAT":
                            {
                                dataColumn.Visible = true;
                            }
                            break;
                        default:
                            {
                                dataColumn.Visible = false;
                            }
                            break;
                    }
    
                    dataGridView1.Columns.Add(dataColumn);
                }
            }       
        }
