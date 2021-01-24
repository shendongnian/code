    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                dt.Columns.Add("Comment", typeof(string));
                dt.Columns.Add("Client", typeof(string));
                dt.Columns.Add("Path", typeof(string));
                dt.Columns.Add("Segment", typeof(int));
                dt.Columns.Add("Exists", typeof(Boolean));
                dt.Columns.Add("Valid", typeof(Boolean));
                dt.Columns.Add("Needs Convert", typeof(Boolean));
                dt.Columns.Add("New Name", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Actual Target Language", typeof(string));
                dt.Columns.Add("Actual Source Language", typeof(string));
                dt.Columns.Add("Desired Target Language", typeof(string));
                dt.Columns.Add("Desired Source Language", typeof(string));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement translationMemory in doc.Descendants("TranslationMemory"))
                {
                    dt.Rows.Add(new object[] {
                        (string)translationMemory.Element("Comment"),
                        (string)translationMemory.Element("Client"),
                        (string)translationMemory.Element("Path"),
                        (int)translationMemory.Element("segment"),
                        (Boolean)translationMemory.Element("Exists"),
                        (Boolean)translationMemory.Element("Valid"),
                        (Boolean)translationMemory.Element("NeedsConvert"),
                        (string)translationMemory.Element("NewName"),
                        (string)translationMemory.Element("Name"),
                        (string)translationMemory.Element("ActualLanguagePair").Element("targetLanguage"),
                        (string)translationMemory.Element("ActualLanguagePair").Element("sourceLanguage"),
                        (string)translationMemory.Element("DesiredLanguagePair").Element("targetLanguage"),
                        (string)translationMemory.Element("DesiredLanguagePair").Element("sourceLanguage")
                    });
                }
                
                dataGridView1.DataSource = dt;
            }
        }
    }
