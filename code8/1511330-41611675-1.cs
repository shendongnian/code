    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks; 
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    namespace Popeye_Booking_application
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                if (File.Exists(FILENAME))
                {
                    dt.ReadXml(FILENAME);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    dt.TableName = "Data";
                    dt.Columns.Add("Data1",typeof(string));
                    dt.Columns.Add("Data2", typeof(string));
                    dt.Columns.Add("Data3", typeof(string));
                    dt.Columns.Add("Data4", typeof(string));
                    dt.Columns.Add("Data5", typeof(string));
                    dt.Columns.Add("Data6", typeof(string));
                    dt.Columns.Add("Data7", typeof(string));
                    SaveXml.SaveData(dt, FILENAME);
                }
            }
            private void buttonCreate_Click(object sender, EventArgs e)
            {
                try
                {
                    Information info = new Information();
                    info.Data1 = textBoxData1.Text;
                    info.Data2 = textBoxData2.Text;
                    info.Data3 = textBoxData3.Text;
                    info.Data4 = textBoxData4.Text;
                    info.Data5 = textBoxData5.Text;
                    info.Data6 = textBoxData6.Text;
                    info.Data7 = textBoxData7.Text;
                    dt.Rows.Add(new object[] {
                        info.Data1,
                        info.Data2,
                        info.Data3,
                        info.Data4,
                        info.Data5,
                        info.Data6,
                        info.Data7
                    });
                    dt.AcceptChanges();
                    
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                    SaveXml.SaveData(dt, FILENAME);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            private void label1_Click(object sender, EventArgs e)
            {
            }
            private void label4_Click(object sender, EventArgs e)
            {
            }
            private void label10_Click(object sender, EventArgs e)
            {
            }
            private void label7_Click(object sender, EventArgs e)
            {
            }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            }
        }
        public class SaveXml
        {
            public static void SaveData(DataTable dt, string filename)
            {
                dt.WriteXml(filename, XmlWriteMode.WriteSchema);
            }
        }
        public class Information
        {
            private string data1;
            private string data2;
            private string data3;
            private string data4;
            private string data5;
            private string data6;
            private string data7;
            public string Data1
            {
                get { return data1; }
                set { data1 = value; }
            }
            public string Data2
            {
                get { return data2; }
                set { data2 = value; }
            }
            public string Data3
            {
                get { return data3; }
                set { data3 = value; }
            }
            public string Data4
            {
                get { return data4; }
                set { data4 = value; }
            }
            public string Data5
            {
                get { return data5; }
                set { data5 = value; }
            }
            public string Data6
            {
                get { return data6; }
                set { data6 = value; }
            }
            public string Data7
            {
                get { return data7; }
                set { data7 = value; }
            }
        }
    }
