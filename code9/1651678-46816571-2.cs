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
                //fillTheListBox(@"C:\temp\myfile.csv");
                fillTheListBox(@"C:\temp\myfile.csv", true);
            }
    
            /// <summary>
            /// Lets say you want to show field value only
            /// </summary>
            /// <param name="filePath"></param>
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
    
    
            /// <summary>
            /// Lets say you wanted to show "Header" : "FieldValue"
            /// </summary>
            /// <param name="filePath"></param>
            /// <param name="ShowHeader"></param>
            private void fillTheListBox(string filePath, bool ShowHeader)
            {
                List<string> headerLine = new List<string>();
                List<string> results = new List<string>();
                int whichLineAmIon = 0;
                string currentLine = string.Empty;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while ((currentLine = sr.ReadLine()) != null)//for as long as there is something to read
                    {
                        string[] splitted = currentLine.Split(',');//split the line into fields
                        for (int i = 0; i < splitted.Length; i++)
                        {
                            if (whichLineAmIon == 0)//then we are on the header line
                            {
                                headerLine.Add(splitted[i]);
                            }
                            else
                            {
                                results.Add(headerLine[i] + " : " + splitted[i]);//add each individual field to the dataSource to create your 1FieldPerLine visual
                            }
                        }
                        whichLineAmIon++;
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
