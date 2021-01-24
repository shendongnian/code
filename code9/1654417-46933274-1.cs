    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication3
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            // private DataTable to work with in button1 
            DataTable dtDemo;
            // create an instance of our data class, use it in button1
            Operations ops = new Operations();
            private void button1_Click(object sender, EventArgs e)
            {
                var result = dtDemo.AsEnumerable().FirstOrDefault(row => row.Field<bool>("Used") == false);
                // find first row that is available
                if (result != null)
                {
                    Console.WriteLine(result.Field<string>("FullName"));
                    // mark it as used
                    result.SetField<bool>("Used", true);
                }
                else
                {
                    Console.WriteLine("Done"); // we have used all rows
                }
            }
            /// <summary>
            /// Load our data
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void Form1_Load(object sender, EventArgs e)
            {
                dtDemo = ops.Read();
            }
        }
    }
