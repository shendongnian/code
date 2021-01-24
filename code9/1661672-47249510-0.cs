    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace GroupBoxRnd
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            IList<GroupBox> groupboxList = new List<GroupBox>();
            Random groupBoxChooser = new Random();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // Find all group boxes
                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(GroupBox))
                        groupboxList.Add((GroupBox)control);
                }
    
                // Hide all of them
                foreach (GroupBox box in groupboxList)
                {
                    box.Hide();
                }
    
                // Show a random one
                var luckyNumber = groupBoxChooser.Next(0, groupboxList.Count);
                groupboxList[luckyNumber].Show();
            }
        }
    }
