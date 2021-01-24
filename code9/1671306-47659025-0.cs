    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication7
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("StudentId", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                dt.Columns.Add("LessonStudy", typeof(string));
                dt.Columns.Add("GroupName", typeof(string));
                dt.Columns.Add("Bell1", typeof(string));
                dt.Columns.Add("Bell2", typeof(string));
                dt.Columns.Add("Bell3", typeof(string));
                dt.Columns.Add("Bell4", typeof(string));
                List<StudentInfo> studentInfo = new List<StudentInfo>() {
                   new StudentInfo() { FullName = "John", GroupName = "Apple", LessonStudy = "Math", StudentId = 123, StatusStudentBell = new StatusStudentBell() { Bell1 = "A", Bell2 = "B", Bell3 = "C", Bell4 = "D"}},
                   new StudentInfo() { FullName = "Marry", GroupName = "Bannana", LessonStudy = "English", StudentId = 345, StatusStudentBell = new StatusStudentBell() { Bell1 = "E", Bell2 = "F", Bell3 = "G", Bell4 = "H"}},
                   new StudentInfo() { FullName = "Harry", GroupName = "Grape", LessonStudy = "French", StudentId = 678, StatusStudentBell = new StatusStudentBell() { Bell1 = "I", Bell2 = "J", Bell3 = "K", Bell4 = "L"}},
                   new StudentInfo() { FullName = "July", GroupName = "Pinapple", LessonStudy = "Gym", StudentId = 246, StatusStudentBell = new StatusStudentBell() { Bell1 = "M", Bell2 = "N", Bell3 = "O", Bell4 = "P"}}
                };
                foreach (StudentInfo info in studentInfo)
                {
                    dt.Rows.Add(new object[] { info.FullName, info.GroupName, info.LessonStudy, info.StudentId, info.StatusStudentBell.Bell1, info.StatusStudentBell.Bell2, info.StatusStudentBell.Bell3, info.StatusStudentBell.Bell4 });
                }
                dataGridView1.DataSource = dt;
            }
            class StudentInfo
            {
                public int StudentId { get; set; }
                public String FullName { get; set; }
                public String LessonStudy { get; set; }
                public String GroupName { get; set; }
                public StatusStudentBell StatusStudentBell { get; set; }
            }
            class StatusStudentBell
            {
                public String Bell1 { get; set; }
                public String Bell2 { get; set; }
                public String Bell3 { get; set; }
                public String Bell4 { get; set; }
            }
        }
    }
