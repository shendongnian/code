    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        // I didn´t declare all you need
        [STAThread]
        static void Main()
        {
            Form1 yourForm = new Form1();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(yourForm);
            
             foreach (string i in AllCourses.Keys)
            {
                if (TmpStd.coursesF.Contains(i) || TmpStd.coursesIP.Contains(i))
                {
                    continue;
                }
                if (AllCourses[i].prerequired_courses == "None")
                {
                    yourForm.dataGridView1.Rows.Add(i, AllCourses[i].name);
                }
             }
        }
    }
