    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;
    
    namespace PopulateListBoxFromCSV_46815162
    {
        
        public partial class Form1 : Form
        {
            ListBox lstbx = new ListBox();
            public Form1()
            {
                InitializeComponent();
                initializeListBox();
                fillTheListBox(@"C:\temp\myfile.csv");
            }
    
            private void fillTheListBox(string filePath)
            {
                List<string> results = new List<string>();
                string currentLine = string.Empty;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while ((currentLine = sr.ReadLine()) != null)//for as long as there is something to read
                    {
                        foreach (string item in currentLine.Split(','))//split the current line into multiple "fields"
                        {
                            results.Add(item);//add each individual field to the dataSource to create your 1FieldPerLine visual
                        }
                    }
                }
                lstbx.DataSource = results;//bind your datasource
            }
    
            private void initializeListBox()
            {
                lstbx.Dock = DockStyle.Fill;
                lstbx.BackColor = Color.Azure;
                this.Controls.Add(lstbx);
            }
        }
    }
