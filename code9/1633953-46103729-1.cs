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
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                PictureBox pictureBox1 = new PictureBox();
                
                 
            }
         private void button1_Click_1(object sender, EventArgs e)
            {   
                pictureBox1.Location = new System.Drawing.Point(50,50);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(75, 50);
                pictureBox1.BackColor = Color.Black;
                panel1.Controls.Add(pictureBox1);
        }
        
    }
