    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace WindowsFormsApplication24
    {
        public partial class Form1 : Form
        {
            const string FOLDER = @"c:\temp";
            public Form1()
            {
                InitializeComponent();
                dateTimePickerStart.Value = DateTime.Parse("1/1/2017");
                dateTimePickerEnd.Value = DateTime.Now;
                string[] files = Directory.GetFiles(FOLDER).Where(x => (File.GetLastWriteTime(x) >= dateTimePickerStart.Value) && (File.GetLastWriteTime(x) <= dateTimePickerEnd.Value)).ToArray();
     
            }
     
        }
     
    }
