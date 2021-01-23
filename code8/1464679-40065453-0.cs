    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const int TOP_MARGIN = 10;
            const int LEFT_MARGIN = 10;
            const int WIDTH = 200;
            const int HEIGHT = 10;
            const int SPACE = 15;
            const int NUMBER_OF_BOXES = 10;
            public Form1()
            {
                InitializeComponent();
                MasterComboBox.Text = "Present";
                for (int i = 0; i < NUMBER_OF_BOXES; i++)
                {
                    AddComboBox(i);
                }
            }
            List<ComboBox> comboBoxes = new List<ComboBox>();
            private void AddComboBox(int i)
            {
                var comboBoxStudentAttendance = new ComboBox();
                comboBoxStudentAttendance.Top = TOP_MARGIN + i * (SPACE + HEIGHT);
                comboBoxStudentAttendance.Left = LEFT_MARGIN;
                comboBoxStudentAttendance.Width = WIDTH;
                comboBoxStudentAttendance.Height = HEIGHT;
                comboBoxStudentAttendance.Items.Add("");
                comboBoxStudentAttendance.Items.Add("Present");
                comboBoxStudentAttendance.Items.Add("Absent");
                comboBoxStudentAttendance.Items.Add("Late");
                comboBoxStudentAttendance.Items.Add("Sick");
                comboBoxStudentAttendance.Items.Add("Excused");
                comboBoxes.Add(comboBoxStudentAttendance);
                this.Controls.Add(comboBoxStudentAttendance);
            }
            private void DistributeAttendanceButton_Click(object sender, EventArgs e) 
            {
                for (int i = 0; i < comboBoxes.Count; i++)
                {
                    switch (MasterComboBox.Text)
                    {
                        case "Present":
                            comboBoxes[i].Text = "Present";
                            break;
                    }
                }
            }
        }
    }
