    public partial class Form1 : Form {
      private string Excel07ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\YourFilePath\YourFile.xls;Extended Properties='Excel 12.0 Xml;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text'";
      string sheetName;
      DataSet ds;
      List<string> comboBoxData = new List<string>();
      public Form1() {
        InitializeComponent();
        SetDataTablesFromExcel();
        dataGridView1.DataSource = ds.Tables[0];
        comboBox1.DataSource = comboBoxData;
        label1.Text = "TableName: " + ds.Tables[0].TableName + " has " + ds.Tables[0].Rows.Count + " rows";
      }
      private void SetDataTablesFromExcel() {
        ds = new DataSet();
        using (OleDbConnection con = new OleDbConnection(Excel07ConString)) {
          using (OleDbCommand cmd = new OleDbCommand()) {
            using (OleDbDataAdapter oda = new OleDbDataAdapter()) {
              cmd.Connection = con;
              con.Open();
              DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
              for (int i = 0; i < dtExcelSchema.Rows.Count; i++) {
                sheetName = dtExcelSchema.Rows[i]["TABLE_NAME"].ToString();
                DataTable dt = new DataTable();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM [" + sheetName + "]";
                oda.SelectCommand = cmd;
                oda.Fill(dt);
                dt.TableName = sheetName;
                comboBoxData.Add(sheetName.Replace("$", ""));
                ds.Tables.Add(dt);
              }
            }
          }
        }
      }
      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
        int index = comboBox1.SelectedIndex;
        dataGridView1.DataSource = ds.Tables[index];
        label1.Text = "TableName: " + ds.Tables[0].TableName + " has " + ds.Tables[0].Rows.Count + " rows";
      }
    }
