    using System;
    using System.Data;
    using System.IO;
    using System.Windows.Forms;
    
    namespace PopulateGridviewWindowsFormsApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void loadbtnxml_Click(object sender, EventArgs e)
            {
                string xmlString = File.ReadAllText(@"D:\My Apps\WinForm Application\PopulateGridviewWindowsFormsApp\PopulateGridviewWindowsFormsApp\XMLFile1.xml");
                DataTable dtKonto = ConvertXmlStringToDatatable(xmlString);
                dataGridView1.DataSource = dtKonto;
            }
    
            //Convert a xml string to datatable
            public static DataTable ConvertXmlStringToDatatable(string xmlData)
            {
                StringReader sr = new StringReader(xmlData);
                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(sr);
                return theDataSet.Tables[0];
            }
        }
    }
