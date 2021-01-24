    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public class Form1 : System.Windows.Forms.Form
    {
        public static void Main()
        {
            Application.Run(new Form1());
        }
        public Form1()
        {
            var myDataGrid = new DataGrid();
            ClientSize = new System.Drawing.Size(450, 330);
            myDataGrid.Location = new Point(24, 50);
            myDataGrid.Size = new Size(300, 200);
            Controls.Add(myDataGrid);
            myDataGrid.SetDataBinding(MakeDataSet(), "MyTable");
            var tableStyle = new DataGridTableStyle { MappingName = "MyTable" };
            var nameColumnStyle = new DataGridTextBoxColumn { MappingName = "Name" };
            var sumColumnStyle = new DataGridTextBoxColumn
            {
                MappingName = "Sum",
                Width = 170,
                Alignment = HorizontalAlignment.Right
            };
            tableStyle.GridColumnStyles.Add(nameColumnStyle);
            tableStyle.GridColumnStyles.Add(sumColumnStyle);
            myDataGrid.TableStyles.Add(tableStyle);
        }
        private DataSet MakeDataSet()
        {
            var dataSet = new DataSet("myDataSet");
            var table = new DataTable("MyTable");
            var nameCol = new DataColumn("Name");
            var sumCol = new DataColumn("Sum", typeof(float));
            table.Columns.Add(nameCol);
            table.Columns.Add(sumCol);
            dataSet.Tables.Add(table);
            var row1 = table.NewRow();
            row1["Name"] = "Bank";
            row1["Sum"] = 1.25;
            table.Rows.Add(row1);
            var row2 = table.NewRow();
            row2["Name"] = "Hosting";
            row2["Sum"] = 12.5;
            table.Rows.Add(row2);
            return dataSet;
        }
    }
