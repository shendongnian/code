    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication21
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // show gif on a different thread until LongTask finish executing
                System.Threading.Thread waitThread = new System.Threading.Thread(ShowGif);
                waitThread.Start();
                // start a new thread to execute LongTask() parallel to the waitThread 
                System.Threading.Thread longTaskThread = new System.Threading.Thread(LongTask);
                longTaskThread.Start();
            }
    
            // put the code of your task that you want to execute in the background in that method
            private void LongTask()
            {
                // long load...
                for (int i = 0; i < 10; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                }
    
                // the "long task" inside the method finished to execute - dispose safely the picturebox from the GUI
                panel3.Invoke(new Action(pictureBox1.Dispose));
                // add user control to panel3
                panel3.Invoke(new Action(AddUserControl));
                // promt to screen
                label1.Invoke(new Action(NotifyTaskHasFinished));
            }
    
            private void AddUserControl()
            {
                UserControl1 uc = new UserControl1();
                panel3.Controls.Add(uc);
            }
    
            private void ShowGif()
            {
                // use action delegate to update GUI changes from another thread
                panel3.Invoke(new Action(AddGif));
            }
    
            private void AddGif()
            {
                // show .gif animation inside picturebox1
                pictureBox1.Image = WindowsFormsApplication21.Properties.Resources.raw_demo;
            }
    
            private void NotifyTaskHasFinished()
            {
                label1.Text = "LongTask() method has finished and user control was loaded";
            }
        }
    }
