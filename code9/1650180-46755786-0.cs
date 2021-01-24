    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                bool flag = this.openFileDialog1.ShowDialog() != DialogResult.Cancel;
                if (flag)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Col A", typeof(string));
                    dt.Columns.Add("Col B", typeof(string));
                    try
                    {
                        StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                        dataGridView1.AllowUserToAddRows = false;
                        string text = "";
                        for (text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
                        {
                            string[] array = text.Split(new char[] { ':' });
                            dataGridView1.Rows.Add(array);
                        }
                        streamReader.Close();
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("Error" + err.Message );
                    }
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
